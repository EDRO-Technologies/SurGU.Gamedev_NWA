using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour
{
    public event EventHandler onTimeExpired;
    public float timerEvent;
    [SerializeField] Timer timer;  
    void Start()
    {
        onTimeExpired += _onTimeExpired;
    }

    private void _onTimeExpired(object sender, EventArgs e)
    {
        
    }


    void Update()
    {
        timerEvent = timer.timeValue;
        if (timerEvent % 30 == 0)
        {
            onTimeExpired?.Invoke(this, EventArgs.Empty);
        }
    }
}
