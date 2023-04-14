using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    [SerializeField] private float maxPower = 4f;

    public Vector3 GetPropellerVector(Rigidbody rb, InputManager input) {
        Vector3 propellerVector = Vector3.zero;
        propellerVector = transform.up * ((rb.mass * Physics.gravity.magnitude) + (input.Pedals * maxPower)) / 4

        return propellerVector;
    }
}
