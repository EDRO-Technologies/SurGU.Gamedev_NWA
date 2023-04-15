using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadcopterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private InputManager input;

	private void Start() {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<InputManager>();
    }
}


