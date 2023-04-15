using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    
    public float timeValue = 90;
    public Text timerText;
    public PauseMenu pauseMenu;
        void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        } else
        {
            timeValue = 0;
            pauseMenu.endGameUI.SetActive(true);
            pauseMenu.eventListUI.SetActive(false);
        }

        DisplayTime(timeValue);

    }


    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
/*
if timeValue % 30 = 0
{
    eventscript.balka.fire
    
}
*/