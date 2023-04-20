using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balka : MonoBehaviour
{
    [SerializeField] EventsSystem eventSystem;

    public ParticleSystem fireParticles;
    [SerializeField] private int balkaId;

    [SerializeField] public GameObject balkaHud;
    [SerializeField] public GameObject balkaHudHolder;

    [SerializeField] public Animator snapAnim;
    [SerializeField] public AudioSource snapSound;

    [SerializeField] public Vector3 qrOffset;

    public float disasterDuration = 60f;

    [SerializeField] public GameObject endGameScreen;
    [SerializeField] public TMP_Text endGameText;
    [SerializeField] public GameObject eventListUI;
    private float disasterTime;
    public bool isDisasterActive = false;


    private void Start()
    {
        eventSystem.onTimeExpired += EventsSystem_onTimeExpired;
        fireParticles = GetComponentInChildren<ParticleSystem>();
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
        if (balkaId != e.objId) return;
        Debug.Log(e.objId);

        switch (e.objId) {
            case 0:
            case 1:
            case 2:
                isDisasterActive = true;
                disasterTime = disasterDuration;
                fireParticles.Play();
                balkaHud.transform.SetParent(balkaHudHolder.transform, false);
                balkaHud.GetComponent<TMP_Text>().text = "Fire Alarm - 50s";
                balkaHud.SetActive(true);
                break;
            case 3:
            case 4:
            case 5:
                isDisasterActive = true;
                disasterTime = disasterDuration;
                transform.position += qrOffset;
                balkaHud.transform.SetParent(balkaHudHolder.transform, false);
                balkaHud.GetComponent<TMP_Text>().text = $"Identify QR {e.objId - 2} - 60s";
                balkaHud.SetActive(true);
                break;
        }
    }

}
