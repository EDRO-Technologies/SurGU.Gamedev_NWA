using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadcopterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private InputManager input;
    [SerializeField] private Propeller FR_propeller;
    [SerializeField] private Propeller FL_propeller;
    [SerializeField] private Propeller BR_propeller;
    [SerializeField] private Propeller BL_propeller;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<InputManager>();
    }

    private void FixedUpdate() {

    }
}
