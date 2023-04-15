using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{   
    [SerializeField] private float maxPower = 4f;

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
        float propellerPower = 0;
        propellerPower = ((rb.mass * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4;

        Vector3 forceVector = Vector3.up * propellerPower;

        rb.AddForce(forceVector, ForceMode.Force);
    }
}
