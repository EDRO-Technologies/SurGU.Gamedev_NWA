using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsSystem : MonoBehaviour
{
    [SerializeField] private float timerDuration = 12f;
    [SerializeField] private float procDuration = 30f;

    public event EventHandler<TimerEventArgs> onTimeExpired;    
    public class TimerEventArgs : EventArgs
    {
        public int disasterId;
    }

    private float eventTimer = 3f;
    private float procTimer = 3f;

    void Update()
    {
        eventTimer -= Time.deltaTime;
        procTimer -= Time.deltaTime;
        eventTimer = Mathf.Max(0,eventTimer);
        procTimer = Mathf.Max(0, procTimer);

        if (eventTimer == 0 || procTimer == 0)
        {
            if (UnityEngine.Random.Range(0, 100) >= 50 || procTimer == 0) {
                onTimeExpired?.Invoke(this, new TimerEventArgs { disasterId = UnityEngine.Random.Range(0, 2) });
                procTimer = procDuration;
                eventTimer = timerDuration;
            }
            eventTimer = timerDuration;
        }
    }
}
