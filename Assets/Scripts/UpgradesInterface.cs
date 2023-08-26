using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UpgradesInterface : MonoBehaviour
{
    public GameObject dashCurrentValueGO, dashNextValueGO, dashCostGO, dashArrowGO, dashCostBoxGO, retryButton, 
                      glideCurrentValueGO, glideNextValueGO, glideCostGO, glideArrowGO, glideCostBoxGO,
                      glideCtrlCurrentValueGO, glideCtrlNextValueGO, glideCtrlCostGO, glideCtrlArrowGO, glideCtrlCostBoxGO;
    private GameObject player;
    private TMP_Text dashCurrentValue, dashNextValue, dashCost,
                     glideCurrentValue, glideNextValue, glideCost,
                     glideCtrlCurrentValue, glideCtrlNextValue, glideCtrlCost;
    private PlayerMove playerMoveScript;
    private PlayerUpgrades playerUpgradesScript;
    public bool dashCDMaxed, glideTimeMaxed, glideCtrlMaxed;
    private EventSystem eventSystem;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerMoveScript = player.GetComponent<PlayerMove>();
        playerUpgradesScript = player.GetComponent<PlayerUpgrades>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.SetSelectedGameObject(retryButton);

        //dash CD
        dashCurrentValue = dashCurrentValueGO.GetComponent<TMP_Text>();
        dashNextValue = dashNextValueGO.GetComponent<TMP_Text>();
        if (!dashCDMaxed)
        {
            dashCurrentValue.text = Mathf.Clamp(playerMoveScript.dashCooldown, 1, 2).ToString() + "S";
            dashNextValue.text = Mathf.Clamp((playerMoveScript.dashCooldown - playerUpgradesScript.dashCooldownReduction), 1, 2).ToString() + "S";
            dashCost = dashCostGO.GetComponent<TMP_Text>();
            dashCost.text = player.GetComponent<PlayerUpgrades>().dashCooldownCost.ToString() + " P";
        }
        else
        {
            dashCurrentValue.text = Mathf.Clamp(playerMoveScript.dashCooldown, 1, 2).ToString() + "S (MAX)";
            dashCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), dashCurrentValue.rectTransform.localRotation);
            dashNextValueGO.SetActive(false);
            dashArrowGO.SetActive(false);
            dashCostBoxGO.SetActive(false);
        }

        //glide time
        /*glideCurrentValue = dashCurrentValueGO.GetComponent<TMP_Text>();
        glideNextValue = dashNextValueGO.GetComponent<TMP_Text>();
        if (!glideTimeMaxed)
        {
            glideCurrentValue.text = playerMoveScript.glideMaxTime.ToString() + "S";
            glideNextValue.text = (playerMoveScript.glideMaxTime + playerUpgradesScript.glideMovementUpgrade).ToString() +"S";
            glideCost = dashCostGO.GetComponent<TMP_Text>();
            glideCost.text = playerUpgradesScript.glideTimerUpgradeCost.ToString() + "P";
        }
        else
        {
            glideCurrentValue.text = playerMoveScript.glideMaxTime.ToString() + "S (MAX)";
            glideCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), glideCurrentValue.rectTransform.localRotation);
            glideNextValueGO.SetActive(false);
            glideArrowGO.SetActive(false);
            glideCostBoxGO.SetActive(false);
        }*/
    }

    public void UpdateDashCDCard()
    {
        dashCurrentValue.text = Mathf.Clamp((playerMoveScript.dashCooldown - playerUpgradesScript.dashCooldownReduction), 1, 2).ToString() + "S";
        dashNextValue.text = Mathf.Clamp((playerMoveScript.dashCooldown - playerUpgradesScript.dashCooldownReduction - playerUpgradesScript.dashCooldownReduction), 1, 2).ToString() + "S";
    }

    public void MaxDashCDCard()
    {
        dashCDMaxed = true;
        dashCurrentValue.text = Mathf.Clamp((playerMoveScript.dashCooldown - playerUpgradesScript.dashCooldownReduction), 1, 2).ToString() + "S (MAX)";
        dashCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), dashCurrentValue.rectTransform.localRotation);
        dashNextValueGO.SetActive(false);
        dashArrowGO.SetActive(false);
        dashCostBoxGO.SetActive(false);
    }

    public void UpdateGlideSecondsCard()
    {
        glideCurrentValue.text = (playerMoveScript.glideMaxTime + playerUpgradesScript.glideTimerUpgrade).ToString() + "S";
        glideNextValue.text = (playerMoveScript.glideMaxTime + playerUpgradesScript.glideTimerUpgrade + playerUpgradesScript.glideTimerUpgrade).ToString() + "S";
    }

    public void MaxGlideSecondsCard()
    {
        glideTimeMaxed = true;
        glideCurrentValue.text = playerMoveScript.glideMaxTime.ToString() + "S (MAX)";
        glideCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), glideCurrentValue.rectTransform.localRotation);
        glideNextValueGO.SetActive(false);
        glideArrowGO.SetActive(false);
        glideCostBoxGO.SetActive(false);
    }
}
