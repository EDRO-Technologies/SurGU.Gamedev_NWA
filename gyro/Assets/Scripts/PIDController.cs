using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;

public class PIDController : NetworkBehaviour
{
	[SerializeField] private Propeller FR_propellerScript;
	[SerializeField] private Propeller FL_propellerScript;
	[SerializeField] private Propeller BR_propellerScript;
	[SerializeField] private Propeller BL_propellerScript;

	[SerializeField] private float targetThrottle;
	[SerializeField] private float targetPitch;
	[SerializeField] private float targetRoll;
	[SerializeField] private float targetYaw;

	[SerializeField] private float throttleMax = 0.6f;
	[SerializeField] private float pitchMax = 0.6f;
	[SerializeField] private float rollMax = 0.6f;
	[SerializeField] private float yawMax = 0.6f;

	public float pitchLimit;
	public float rollLimit;
	public float throttleLimit;

	private float pitch;
	private float roll;
	private float yaw;
	public float throttle;

	[SerializeField]  private PID throttlePID;
	[SerializeField]  private PID pitchPID;
	[SerializeField]  private PID rollPID;
	[SerializeField]  private PID yawPID;

	private InputManager input;
	[SerializeField] private Transform bodyTransform;

    public override void OnStartClient()
    {
        base.OnStartClient();
		if (!base.IsOwner) {
			GetComponent<PIDController>().enabled = false;
		}
    }

    private void Awake()
    {
		input = GetComponent<InputManager>();
	}

    void FixedUpdate()
	{
		Stabilize(input);
	}

	private void Stabilize(InputManager input)
	{
		pitch = bodyTransform.eulerAngles.x;
		yaw = bodyTransform.eulerAngles.y;
		roll = bodyTransform.eulerAngles.z;
		throttle = bodyTransform.transform.position.y;

		float FL_propPower = 1;
		float FR_propPower = 1;
		float BL_propPower = 1;
		float BR_propPower = 1;

		targetPitch = pitchLimit * input.PitchNRoll.y;
		targetRoll = -rollLimit * input.PitchNRoll.x;
		targetYaw += input.Yaw;
		targetThrottle += input.Throttle / 100f * throttleLimit;

		pitch -= Mathf.Ceil(Mathf.Floor(pitch / 180) / 2) * 360;
		targetPitch -= Mathf.Ceil(Mathf.Floor(pitch / 180) / 2) * 360;

		roll -= Mathf.Ceil(Mathf.Floor(roll / 180) / 2) * 360;
		targetRoll -= Mathf.Ceil(Mathf.Floor(roll / 180) / 2) * 360;

		yaw = Mathf.LerpAngle(yaw, targetYaw, 0);
		targetYaw = Mathf.LerpAngle(yaw, targetYaw, 1);

		float throttleForce = throttlePID.CalculateForce(throttle, targetThrottle);
		throttleForce = Mathf.Clamp(throttleForce, -throttleMax, throttleMax);
		FL_propPower += throttleForce;
		FR_propPower += throttleForce;
		BL_propPower += throttleForce;
		BR_propPower += throttleForce;

		float pitchForce = pitchPID.CalculateForce(pitch, targetPitch);
		pitchForce = Mathf.Clamp(pitchForce, -pitchMax, pitchMax);
		FL_propPower -= pitchForce;
		FR_propPower -= pitchForce;
		BL_propPower += pitchForce;
		BR_propPower += pitchForce;

		float rollForce = rollPID.CalculateForce(roll, targetRoll);
		rollForce = Mathf.Clamp(rollForce, -rollMax, rollMax);
		FL_propPower -= rollForce;
		FR_propPower += rollForce;
		BL_propPower -= rollForce;
		BR_propPower += rollForce;

		float yawForce = -yawPID.CalculateForce(yaw, targetYaw);
		yawForce = Mathf.Clamp(yawForce, -yawMax, yawMax);
		FL_propPower -= yawForce;
		FR_propPower += yawForce;
		BL_propPower += yawForce;
		BR_propPower -= yawForce;

		// Debug.Log("1. " + throttleForce + " 2. " + pitchForce + " 3. " + rollForce + " 4. " + yawForce);

		FL_propellerScript.rpm = FL_propPower;
		FR_propellerScript.rpm = FR_propPower;
		BL_propellerScript.rpm = BL_propPower;
		BR_propellerScript.rpm = BR_propPower;
	}
}
