using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CnemachineConstroller : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera thirdPerson;
    [SerializeField] private CinemachineVirtualCamera firstPerson;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            if (thirdPerson.Priority == 11) {
                thirdPerson.Priority -= 2;
            } else if (thirdPerson.Priority == 9) {
                thirdPerson.Priority += 2;
            }
        }
    }
}
