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
                      glideCtrlCurrentValueGO, glideCtrlNextValueGO, glideCtrlCostGO, glideCtrlArrowGO, glideCtrlCostBoxGO,
                      lifesCurrentValueGO, lifesNextValueGO, lifesCostGO, lifesArrowGO, LifesCostBoxGO;
    private GameObject player;
    private TMP_Text dashCurrentValue, dashNextValue, dashCost,
                     glideCurrentValue, glideNextValue, glideCost,
                     glideCtrlCurrentValue, glideCtrlNextValue, glideCtrlCost,
                     lifesCurrentValue, lifesNextValue, lifesCost;
    private PlayerMove playerMoveScript;
    private PlayerUpgrades playerUpgradesScript;
    public bool dashCDMaxed, glideTimeMaxed, glideCtrlMaxed, lifesMaxed;
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
        if (playerUpgradesScript.currentCooldownUpgrades < playerUpgradesScript.maxDashCooldownUpgrade)
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
        glideCurrentValue = glideCurrentValueGO.GetComponent<TMP_Text>();
        glideNextValue = glideNextValueGO.GetComponent<TMP_Text>();
        if (playerUpgradesScript.currentglideTimerUpgrade < playerUpgradesScript.maxglideTimerUpgrade)
        {
            glideCurrentValue.text = playerMoveScript.glideMaxTime.ToString() + "S";
            glideNextValue.text = (playerMoveScript.glideMaxTime + playerUpgradesScript.glideTimerUpgrade).ToString() +"S";
            glideCost = glideCostGO.GetComponent<TMP_Text>();
            glideCost.text = playerUpgradesScript.glideTimerUpgradeCost.ToString() + "P";
        }
        else
        {
            glideCurrentValue.text = playerMoveScript.glideMaxTime.ToString() + "S (MAX)";
            glideCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), glideCurrentValue.rectTransform.localRotation);
            glideNextValueGO.SetActive(false);
            glideArrowGO.SetActive(false);
            glideCostBoxGO.SetActive(false);
        }

        //glidecontrol
        glideCtrlCurrentValue = glideCtrlCurrentValueGO.GetComponent<TMP_Text>();
        glideCtrlNextValue = glideCtrlNextValueGO.GetComponent<TMP_Text>();
        if (playerUpgradesScript.currentglideMovementUpgrade < playerUpgradesScript.maxglideMovementUpgrade)
        {
            glideCtrlCurrentValue.text = playerMoveScript.glideMaxMove.ToString();
            glideCtrlNextValue.text = (playerMoveScript.glideMaxMove + playerUpgradesScript.glideMovementUpgrade).ToString();
            glideCtrlCost = glideCtrlCostGO.GetComponent<TMP_Text>();
            glideCtrlCost.text = playerUpgradesScript.glideMovementUpgradeCost.ToString() + "P";
        }
        else
        {
            glideCtrlCurrentValue.text = playerMoveScript.glideMaxMove.ToString() + "(MAX)";
            glideCtrlCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), glideCtrlCurrentValue.rectTransform.localRotation);
            glideCtrlNextValueGO.SetActive(false);
            glideCtrlArrowGO.SetActive(false);
            glideCtrlCostBoxGO.SetActive(false);
        }

        //extra lifes
        lifesCurrentValue = lifesCurrentValueGO.GetComponent<TMP_Text>();
        lifesNextValue = lifesNextValueGO.GetComponent<TMP_Text>();
        if (playerUpgradesScript.currentglideLifesUpgrade < playerUpgradesScript.maxLifesUpgrade)
        {
            lifesCurrentValue.text = playerMoveScript.MaxLifes.ToString();
            lifesNextValue.text = (playerMoveScript.MaxLifes + playerUpgradesScript.lifeUpgrade).ToString();
            lifesCost = lifesCostGO.GetComponent<TMP_Text>();
            lifesCost.text = playerUpgradesScript.lifeUpgradeCost.ToString() + "P";
        }
        else
        {
            lifesCurrentValue.text = playerMoveScript.MaxLifes.ToString() + "(MAX)";
            lifesCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), glideCtrlCurrentValue.rectTransform.localRotation);
            lifesNextValueGO.SetActive(false);
            lifesArrowGO.SetActive(false);
            LifesCostBoxGO.SetActive(false);
        }
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
        glideCurrentValue.text = playerMoveScript.glideMaxTime.ToString() + "S";
        glideNextValue.text = (playerMoveScript.glideMaxTime + playerUpgradesScript.glideTimerUpgrade).ToString() + "S";
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

    public void UpdateGlideControlCard()
    {
        glideCtrlCurrentValue.text = playerMoveScript.glideMaxMove.ToString();
        glideCtrlNextValue.text = (playerMoveScript.glideMaxMove + playerUpgradesScript.glideMovementUpgrade).ToString();
    }

    public void MaxGlideControlCard()
    {
        glideCtrlMaxed = true;
        glideCtrlCurrentValue.text = playerMoveScript.glideMaxMove.ToString() + "(MAX)";
        glideCtrlCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), glideCtrlCurrentValue.rectTransform.localRotation);
        glideCtrlNextValueGO.SetActive(false);
        glideCtrlArrowGO.SetActive(false);
        glideCtrlCostBoxGO.SetActive(false);
    }

    public void UpdateLifesCard()
    {
        lifesCurrentValue.text = playerMoveScript.MaxLifes.ToString();
        lifesNextValue.text = (playerMoveScript.MaxLifes + playerUpgradesScript.lifeUpgrade).ToString();
    }

    public void MaxLifesCard()
    {
        lifesMaxed = true;
        lifesCurrentValue.text = playerMoveScript.MaxLifes.ToString() + "(MAX)";
        lifesCurrentValue.rectTransform.SetLocalPositionAndRotation(new Vector3(0, -40.36f, 0), glideCtrlCurrentValue.rectTransform.localRotation);
        lifesNextValueGO.SetActive(false);
        lifesArrowGO.SetActive(false);
        LifesCostBoxGO.SetActive(false);
    }
}
