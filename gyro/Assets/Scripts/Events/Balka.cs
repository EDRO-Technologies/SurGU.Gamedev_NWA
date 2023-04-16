using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balka : MonoBehaviour
{
    [SerializeField] EventsSystem eventSystem;

    [SerializeField] ParticleSystem firePrefab;

    [SerializeField] private float disasterDuration = 20f;

    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private TMP_Text endGameText;
    [SerializeField] private GameObject eventListUI;
    private float disasterTime;
    private bool isDisasterActive = false;

    private void Start()
    {
        eventSystem.onTimeExpired += EventsSystem_onTimeExpired;
    }

    private void Update()
    {
        if (isDisasterActive)
        {
            disasterTime -= Time.deltaTime;

            if (disasterTime <= 0)
            {
                endGameText.text = "You've lost!";
                eventListUI.SetActive(false);
                endGameScreen.SetActive(true);
            }
        }
    }

    private void EventsSystem_onTimeExpired(object sender, EventsSystem.TimerEventArgs e) 
    {
        Debug.Log(e.disasterId);

        switch(e.disasterId) {
            case 0:
                isDisasterActive = true;
                disasterTime = disasterDuration;
                ParticleSystem fireParticles = Instantiate(firePrefab);
                fireParticles.transform.position = transform.position;

                fireParticles.Play();
                Debug.Log("ASDQWE");
                break;
            case 1:
                Debug.Log("GOOFY AHH");
                break;
        }
    }

}
