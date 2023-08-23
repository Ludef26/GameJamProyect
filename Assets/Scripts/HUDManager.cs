using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public GameObject glideIndicator, dashIndicator;
    private Image glideTimerCircle, dashTimerCircle;

    private void Start()
    {
        glideTimerCircle = glideIndicator.GetComponent<Image>();
    }

    public void UpdateGlideIndicator(float timerValue, float maxTime)
    {
        glideTimerCircle.fillAmount = timerValue / maxTime;
    }
}
