using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;
using UnityEngine.UI;
using TMPro;

public class UIControllers : NetworkBehaviour
{
    public PIDController playerController;

    /*
    private float pitchLimit = 10;
    private float rollLimit = 10;
    private float throttleLimit = 2;
    */

    [SerializeField] private Slider pitchSlider;
    [SerializeField] private Slider rollSlider;
    [SerializeField] private Slider throttleSlider;

    [SerializeField] private TMP_Text pitchText;
    [SerializeField] private TMP_Text rollText;
    [SerializeField] private TMP_Text throttleText;

    private void Update()
    {
        if (playerController != null) {
            playerController.pitchLimit = pitchSlider.value;
            playerController.rollLimit = rollSlider.value;
            playerController.throttleLimit = throttleSlider.value;

            pitchText.text = $"{pitchSlider.value}°";
            rollText.text = $"{rollSlider.value}°";
            throttleText.text = $"{Mathf.Round(throttleSlider.value * 5)}%";
        }
    }
}
