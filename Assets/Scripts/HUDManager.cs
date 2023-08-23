using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public GameObject glideIndicator, dashIndicator;
    private Image glideTimerCircle, dashTimerCircle;
    private Animator animator;

    private void Start()
    {
        glideTimerCircle = glideIndicator.GetComponent<Image>();
        dashTimerCircle = dashIndicator.GetComponent<Image>();
        animator = GetComponent<Animator>();
    }

    public void UpdateGlideIndicator(float timerValue, float maxTime)
    {
        glideTimerCircle.fillAmount = timerValue / maxTime;
    }

    public void UpdateDashIndicator(float auxDashCooldown, float dashCooldown)
    {
        dashTimerCircle.fillAmount = dashCooldown / auxDashCooldown;
    }

    public void PlayShakeAnimation()
    {
        animator.Play("GlideIndicatorShake", 0, 0);
    }

    public void PlayBlinkAnimation()
    {
        animator.Play("DashIndicatorBlink", 0, 0);
    }
}
