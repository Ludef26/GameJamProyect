using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesInterface : MonoBehaviour
{
    private GameObject dashCurrentValueGO, dashNextValueGO, dashCostGO, player;
    private TMP_Text dashCurrentValue, dashNextValue, dashCost;
    private PlayerMove playerScript;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMove>();

        dashCurrentValue = dashCurrentValueGO.GetComponent<TextMeshProUGUI>();
        dashNextValue = dashNextValueGO.GetComponent<TextMeshProUGUI>();
        dashCost = dashCostGO.GetComponent<TextMeshProUGUI>();
        dashCost.text = player.GetComponent<PlayerUpgrades>().dashCooldownCost.ToString();



    }

    public void UpdateDashCDCard(float dashCooldownReduction)
    {
        dashCurrentValue.text = (playerScript.dashCooldown - dashCooldownReduction).ToString();
        dashNextValue.text = (playerScript.dashCooldown - dashCooldownReduction - dashCooldownReduction).ToString();
    }

    public void UpdateGlideSecondsCard(float GlideSecondsIncrease)
    {

    }
}
