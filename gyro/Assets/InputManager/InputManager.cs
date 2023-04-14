using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private float pedals;
    private float throttle;

    public float Pedals { get => pedals; }
    public float Throttle { get => throttle; }

    private void OnPedals(InputValue value) {
        pedals = value.Get<float>();
    }

    private void OnThrottle(InputValue value) {
        throttle = value.Get<float>();
    }
}
