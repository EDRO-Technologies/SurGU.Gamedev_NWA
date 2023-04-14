using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadcopterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private InputManager input;
    [SerializeField] private List<GameObject> propellers = new List<GameObject>();

    private void Start() {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<InputManager>();
    }

    private void FixedUpdate() {
        foreach (GameObject propeller in propellers) {
            Propeller propellerScript = propeller.GetComponent<Propeller>();

            float propellerPower = propellerScript.GetPropellerVector(rb, input);
            Vector3 propellerVector = new Vector3(transform.rotation.x, propellerPower, transform.rotation.z);

            rb.AddRelativeForce(propellerVector, ForceMode.Force);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z) + rb.centerOfMass, 0.25f);
    }
}
