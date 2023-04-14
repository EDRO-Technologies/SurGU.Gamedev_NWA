using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadcopterMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Vector3 gravityVector = new Vector3(0, -10f, 0);
    [SerializeField] private List<GameObject> propellers = new List<GameObject>();

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update() {
        rb.AddForce(gravityVector, ForceMode.Force);

        foreach(GameObject propeller in propellers) {
            Propeller propellerScript = propeller.GetComponent<Propeller>();

            Vector3 propellerVector = propellerScript.GetPropellerVector();

            rb.AddForce(propellerVector, ForceMode.Force);
        }
    }
}
