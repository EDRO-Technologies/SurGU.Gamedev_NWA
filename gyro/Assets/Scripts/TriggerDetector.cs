using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField] private GameObject hudHelp;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Balka") {
            if (other.GetComponent<Balka>().isDisasterActive) {
                TooltipControl(true, "Press F to extinguish");
            }
        } else if (other.tag == "QR") {
            if (other.GetComponent<Balka>().isDisasterActive) {
                TooltipControl(true, "Press F to scan");
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Balka") {
            TooltipControl(false);
        } else if (other.tag == "QR") {
            TooltipControl(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Balka" && other.GetComponent<Balka>().isDisasterActive)
        {
            TooltipControl(true, "Press F to extinguish");
            if (Input.GetKey(KeyCode.F))
            {
                Balka balka = other.GetComponent<Balka>();
                balka.fireParticles.Stop();
                balka.isDisasterActive = false;
                TooltipControl(false);
                balka.balkaHud.transform.SetParent(balka.transform);
            }
        } else if (other.tag == "QR" && other.GetComponent<Balka>().isDisasterActive) {
            TooltipControl(true, "Press F to scan");
            if (Input.GetKey(KeyCode.F)) {
                Balka balka = other.GetComponent<Balka>();
                balka.snapSound.Play();
                balka.snapAnim.Play("FlashbangAnim", 0, 0.0f);
                balka.isDisasterActive = false;
                balka.transform.position -= balka.qrOffset;
                TooltipControl(false);
                balka.balkaHud.transform.SetParent(balka.transform);
            }
        }
    }

    private void TooltipControl(bool state, string text = "") {
        if (!state) {
            hudHelp.SetActive(state);
        } else {
            hudHelp.GetComponentInChildren<TMP_Text>().text = text;
            hudHelp.SetActive(state);
        }
    }
}
