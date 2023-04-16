using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FishNet.Object;
using FishNet.Connection;

public class InputManager : NetworkBehaviour
{
    private float throttle;
    private float yaw;
    private Vector2 pitchNRoll;

    public float Throttle { get => throttle; }
    public float Yaw { get => yaw; }
    public Vector2 PitchNRoll { get => pitchNRoll; }

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            GetComponent<InputManager>().enabled = false;
        }
    }

    private void OnThrottle(InputValue value) {
        throttle = value.Get<float>();
    }

    private void OnYaw(InputValue value) {
        yaw = value.Get<float>();
    }

    private void OnPitchNRoll(InputValue value) {
        pitchNRoll = value.Get<Vector2>();
    }
}
