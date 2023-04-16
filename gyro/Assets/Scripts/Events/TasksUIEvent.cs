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
        switch (e.objId)
        {
            case 0:
            case 1:
            case 2:
                eventText.transform.SetParent(eventTextsHolder.transform, false);
                eventText.GetComponent<TMP_Text>().text = "Fire Alarm - 60s";
                break;
            case 3:
            case 4:
            case 5:
                eventText.transform.SetParent(eventTextsHolder.transform, false);
                eventText.GetComponent<TMP_Text>().text = "Scan the Mark - 60s";
                break;
        }
    }
}