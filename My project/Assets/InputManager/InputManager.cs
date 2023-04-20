using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] List<GameObject> arrows;

    private float throttle;
    private float yaw;
    private Vector2 pitchNRoll;
    private bool isArrowActive = false;

    public float Throttle { get => throttle; }
    public float Yaw { get => yaw; }
    public Vector2 PitchNRoll { get => pitchNRoll; }

    private void OnThrottle(InputValue value) {
        throttle = value.Get<float>();
    }

    private void OnYaw(InputValue value) {
        yaw = value.Get<float>();
    }

    private void OnPitchNRoll(InputValue value) {
        pitchNRoll = value.Get<Vector2>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)) {
            foreach (GameObject arrow in arrows) {
                if(isArrowActive) {
                    arrow.SetActive(false);
                }
                else {
                    arrow.SetActive(true);
                }
            }
            isArrowActive = !isArrowActive;
        }
    }
}
