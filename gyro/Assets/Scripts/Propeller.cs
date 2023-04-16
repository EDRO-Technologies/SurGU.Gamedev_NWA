using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;

public class Propeller : NetworkBehaviour
{   
    [SerializeField] private float torquePower = 4f;
    [SerializeField] private float forcePower = 4f;
    [SerializeField] private float torqueDirection;
    public float rpm;
    public float isBroken = 1;

    private Rigidbody rb;
    [SerializeField] private Rigidbody bodyRb;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            GetComponent<Propeller>().enabled = false;
        }
    }

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        UpdateEngine(rb);
    }

    public void UpdateEngine(Rigidbody rb) {
        rpm = Mathf.Max(0, rpm);
        rb.AddTorque(transform.up * torquePower * rpm * torqueDirection * isBroken);
        rb.AddForce(transform.up * forcePower * rpm * isBroken, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other) {
        isBroken = 0;
    }
}
