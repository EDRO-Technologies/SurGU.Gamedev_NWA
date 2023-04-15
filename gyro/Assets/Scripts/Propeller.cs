using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{   
    [SerializeField] private float maxPower = 4f;
    [SerializeField] private float torquePower = 4f;
    [SerializeField] private float torqueDirection; // -1/1
    public float rpm;

    private Rigidbody rb;
    private InputManager input;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        input = GetComponentInParent<InputManager>();
    }

    private void FixedUpdate() {
        UpdateEngine(rb, input);
    }

    public void UpdateEngine(Rigidbody rb, InputManager input) {
        float propellerPower;
        propellerPower = ((rb.mass * 5 * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4;
        Vector3 forceVector = transform.up * propellerPower * rpm;

        /*
        float inputPower = 1f;
        if (name == "FL_Propeller" || name == "BR_Propeller") {
            inputPower *= 1.2f;
        } else {
            inputPower *= 0.8f;
        }
        */

        rb.AddTorque(transform.up * input.Yaw * torquePower * torqueDirection);

        rb.AddForce(forceVector, ForceMode.Force);
    }
}
