using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TasksUIEvent : MonoBehaviour
{
    [SerializeField] private EventsSystem eventSystem;
    [SerializeField] private GameObject eventTextsHolder;
    [SerializeField] private GameObject eventTextPrefab;

    private void Start()
    {
        eventSystem.onTimeExpired += EventsSystem_onTimeExpired;
    }

    private void EventsSystem_onTimeExpired(object sender, EventsSystem.TimerEventArgs e)
    {
        GameObject eventText = Instantiate(eventTextPrefab);
        switch (e.disasterId)
        {
            case 0:
                eventText.transform.parent = eventTextsHolder.transform;
                eventText.GetComponent<TMP_Text>().text = "Fire Alarm - 60s";
                break;
            case 1:
                eventText.transform.parent = eventTextsHolder.transform;
                eventText.GetComponent<TMP_Text>().text = "Scan the Mark - 60s";
                break;
        }
    }
}