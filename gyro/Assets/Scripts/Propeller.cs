using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    [SerializeField] private float maxPower = 4f;
    [SerializeField] private float pitchChange = 0.25f;
    // [SerializeField] private float rollChange = 1.5f;
    // [SerializeField] private float yawPower = 30f;

    public float GetPropellerVector(Rigidbody rb, InputManager input) {
        float propellerPower = 0;
        propellerPower = ((rb.mass * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4;

        if ((name == "BR_Propeller" || name == "BL_Propeller") && input.PitchNRoll.y > 0) {
            propellerPower += pitchChange;
        } else if ((name == "FR_Propeller" || name == "FL_Propeller") && input.PitchNRoll.y > 0) {
            propellerPower -= pitchChange;
        } else if ((name == "FR_Propeller" || name == "FL_Propeller") && input.PitchNRoll.y < 0) {
            propellerPower += pitchChange;
        } else if ((name == "BR_Propeller" || name == "BL_Propeller") && input.PitchNRoll.y < 0) {
            propellerPower -= pitchChange;
        }

        return propellerPower;
    }
}
