using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{   
    [SerializeField] private float torquePower = 4f;
    [SerializeField] private float forcePower = 4f;
    [SerializeField] private float torqueDirection;
    public float rpm;

    private Rigidbody rb;
    [SerializeField] private Rigidbody bodyRb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        UpdateEngine(rb);
    }

    public void UpdateEngine(Rigidbody rb) {
        rpm = Mathf.Max(0, rpm);
        rb.AddTorque(transform.up * torquePower * rpm * torqueDirection);
        rb.AddForce(transform.up * forcePower * rpm, ForceMode.Force);
    }
}
