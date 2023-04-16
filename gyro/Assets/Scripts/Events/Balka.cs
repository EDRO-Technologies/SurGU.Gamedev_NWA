using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balka : MonoBehaviour
{
    [SerializeField] EventsSystem eventSystem;

    [SerializeField] public ParticleSystem firePrefab;
    [SerializeField] private int balkaId;

    public float disasterDuration = 60f;

    [SerializeField] public GameObject endGameScreen;
    [SerializeField] public TMP_Text endGameText;
    [SerializeField] public GameObject eventListUI;
    private float disasterTime;
    public bool isDisasterActive = false;


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
                OnTimeExpired();
            }
        }
    }

    private void OnTimeExpired() {
        endGameText.text = "You've lost!";
        eventListUI.SetActive(false);
        endGameScreen.SetActive(true);
    }


    private void EventsSystem_onTimeExpired(object sender, EventsSystem.TimerEventArgs e) 
    {
        if (balkaId != e.balkaId) return;

        switch(e.disasterId) {
            case 1:
            case 0:
                isDisasterActive = true;
                disasterTime = disasterDuration;
                ParticleSystem fireParticles = Instantiate(firePrefab);
                fireParticles.transform.position = transform.position;
                fireParticles.Play();
                break;
        }
    }

}
