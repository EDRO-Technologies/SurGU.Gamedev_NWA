using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] Balka balka;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Balka")
        {
            if (Input.GetKey(KeyCode.F))
            {
                balka.firePrefab.Stop();
                balka.isDisasterActive = false;
                //balka.eventListUI.
            }
        }
    }
}
