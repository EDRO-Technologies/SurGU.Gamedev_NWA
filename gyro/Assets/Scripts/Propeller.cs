using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{   
    [SerializeField] private float torquePower = 4f;
    [SerializeField] private float torqueDirection;
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
        Vector3 forceVector = transform.up * rpm;

        
        float inputPower = 1f;
/*        if (name == "FL_Propeller" || name == "BR_Propeller") {
            inputPower *= 1.2f;                                                                                                          
        } else {
            inputPower *= 0.8f;
        }*/
        
        rb.AddTorque(forceVector * input.Yaw * inputPower * torquePower * torqueDirection);
        rb.AddForce(forceVector, ForceMode.Force);
    }
}
