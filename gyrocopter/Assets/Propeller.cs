using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public Vector3 GetPropellerVector() {
        Vector3 propellerVector = new Vector3(1, 2.5f, 0);

        if (gameObject.name == "FrontLeftPropeller" || gameObject.name == "BackRightPropeller") {
            //propellerVector.x = -1;
            //propellerVector.y = 4f;
        }

        // тут чет вычисляем

        return propellerVector;
    }
}
