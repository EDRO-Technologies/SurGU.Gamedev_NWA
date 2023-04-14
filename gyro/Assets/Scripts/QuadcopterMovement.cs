using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadcopterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private InputManager input;
    [SerializeField] private List<GameObject> propellers = new List<GameObject>();

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        input = gameObject.GetComponent<InputManager>();
    }

    private void FixedUpdate() {
        foreach (GameObject propeller in propellers) {
            Propeller propellerScript = propeller.GetComponent<Propeller>();

            Vector3 propellerVector = propellerScript.GetPropellerVector(rb, input);

            rb.AddForce(propellerVector, ForceMode.Force);
        }
    }
}
