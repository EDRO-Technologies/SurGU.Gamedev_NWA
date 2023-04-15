using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIDController : MonoBehaviour
{
	[SerializeField] private GameObject FR_propeller;
	[SerializeField] private GameObject FL_propeller;
	[SerializeField] private GameObject BR_propeller;
	[SerializeField] private GameObject BL_propeller;

	private Propeller FR_propellerScript;
	private Propeller FL_propellerScript;
	private Propeller BR_propellerScript;
	private Propeller BL_propellerScript;

	private Rigidbody FR_propellerRb;
	private Rigidbody FL_propellerRb;
	private Rigidbody BR_propellerRb;
	private Rigidbody BL_propellerRb;

	[SerializeField] private float targetPitch;
	[SerializeField] private float targetRoll;
	[SerializeField] private float targetYaw;

	[SerializeField] private float pitchMax = 0.6f;

	[SerializeField] private float maxPower = 4f;

	private float pitch;
	private float roll;
	private float yaw;
	public float throttle;

	private PID pitchPID = new PID(100, 0, 20);
	private PID rollPID = new PID(100, 0, 20);
	private PID yawPID = new PID(50, 0, 50);

	private InputManager input;


    private void Awake()
    {
		FR_propellerScript = FR_propeller.GetComponent<Propeller>();
		FL_propellerScript = FL_propeller.GetComponent<Propeller>();
		BR_propellerScript = BR_propeller.GetComponent<Propeller>();
		BL_propellerScript = BL_propeller.GetComponent<Propeller>();

		FR_propellerRb = FR_propeller.GetComponent<Rigidbody>();
		FL_propellerRb = FL_propeller.GetComponent<Rigidbody>();
		BR_propellerRb = BR_propeller.GetComponent<Rigidbody>();
		BL_propellerRb = BL_propeller.GetComponent<Rigidbody>();

		input = GetComponent<InputManager>();
	}

    void FixedUpdate()
	{
		GetRotation();
		Stabilize(input);
	}

	private void GetRotation()
	{
		Vector3 rotation = GetComponent<Transform>().rotation.eulerAngles;
		pitch = rotation.x;
		yaw = rotation.y;
		roll = rotation.z;
	}

	private void Stabilize(InputManager input)
	{
		float pitchDiff = targetPitch - pitch;
		float rollDiff = targetRoll - roll;
		float yawDiff = targetYaw - yaw;

		float FL_propPower = throttle;
		float FR_propPower = throttle;
		float BL_propPower = throttle;
		float BR_propPower = throttle;

		FL_propPower = ((FL_propellerRb.mass * 5 * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4;
		FR_propPower = ((FR_propellerRb.mass * 5 * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4;
		BL_propPower = ((BL_propellerRb.mass * 5 * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4;
		BR_propPower = ((BR_propellerRb.mass * 5 * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4;

		float pitchForce = pitchPID.CalculateForce(0, targetPitch / 180f);
		pitchForce = Mathf.Clamp(pitchForce, -pitchMax, pitchMax);
		FL_propPower -= pitchForce;
		FR_propPower -= pitchForce;
		BL_propPower += pitchForce;
		BR_propPower += pitchForce;

		FL_propellerScript.rpm = FL_propPower;
		FR_propellerScript.rpm = FR_propPower;
		BL_propellerScript.rpm = BL_propPower;
		BR_propellerScript.rpm = BR_propPower;
	}
}
