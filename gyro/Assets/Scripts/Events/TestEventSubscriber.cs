using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealEventSystemSubscriber : MonoBehaviour
{
    [SerializeField] TestEvent testEvent;
    private void Start()
    {
        testEvent.onTimeExpired += TestEvent_onTimeExpired;
    }

    private void TestEvent_onTimeExpired (object sender, EventArgs e) 
    {
        Debug.Log("Event started");
    }

}
