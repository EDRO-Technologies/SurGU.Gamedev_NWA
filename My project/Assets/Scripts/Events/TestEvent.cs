using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    public event EventHandler onTimeExpired;
    private float timerEvent = 30;

    void Update()
    {
        timerEvent -= Time.deltaTime;
        timerEvent = Mathf.Max(0,timerEvent);

        if (timerEvent == 0)
        {
            if (UnityEngine.Random.Range(0, 100) >= 50) {
                onTimeExpired?.Invoke(this, EventArgs.Empty);
            }
            timerEvent = 30;
        }
    }
}
