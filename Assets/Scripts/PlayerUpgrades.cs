using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerMove playerStats;
    public float dashCooldownReduction = 0.2f;
    public int maxDashCooldownUpgrade = 5, currentCooldownUpgrades = 0;
    public float dashCooldownCost = 1000;

    public float glideMovementUpgrade = 1.0f;
    public int maxglideMovementUpgrade = 5, currentglideMovementUpgrade = 0;
    public float glideMovementUpgradeCost = 1000;

    public float glideTimerUpgrade = 1.0f;
    public int maxglideTimerUpgrade = 5, currentglideTimerUpgrade = 0;
    public float glideTimerUpgradeCost = 1000;

    public int lifeUpgrade = 1;
    public int maxLifesUpgrade = 2, currentglideLifesUpgrade = 0;
    public float lifeUpgradeCost = 1000;

    public GameObject canvasUpgrades;
    private UpgradesInterface upgradesUI;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerMove>();
        upgradesUI = canvasUpgrades.GetComponent<UpgradesInterface>();
    }

    public void upgradeDashCooldown()
    {
        if (currentCooldownUpgrades < maxDashCooldownUpgrade && playerStats.puntuantion >= dashCooldownCost)
        {
            currentCooldownUpgrades++;
            playerStats.puntuantion -= dashCooldownCost;
            playerStats.dashCooldown -= dashCooldownReduction;

            if(currentCooldownUpgrades != maxDashCooldownUpgrade)
            {
                upgradesUI.UpdateDashCDCard();
            }
            else
            {
                upgradesUI.MaxDashCDCard();
            }
        }
    }
    public void AddLife()
    {
        if (currentglideLifesUpgrade < maxLifesUpgrade && playerStats.puntuantion >= lifeUpgradeCost)
        {
            currentglideLifesUpgrade++;
            playerStats.puntuantion -= lifeUpgradeCost;
            playerStats.MaxLifes += lifeUpgrade;

            if(currentglideLifesUpgrade != maxLifesUpgrade)
            {
                upgradesUI.UpdateLifesCard();
            }
            else
            {
                upgradesUI.MaxLifesCard();
            }
        }
    }
    public void upgradeGlideMovement()
    {
        if (currentglideMovementUpgrade < maxglideMovementUpgrade && playerStats.puntuantion >= glideMovementUpgradeCost)
        {
            currentglideMovementUpgrade++;
            playerStats.puntuantion -= glideMovementUpgradeCost;
            playerStats.glideMaxMove += glideMovementUpgrade;

            if(currentglideMovementUpgrade != maxglideMovementUpgrade)
            {
                upgradesUI.UpdateGlideControlCard();
            }
            else
            {
                upgradesUI.MaxGlideControlCard();
            }
        }
    }
    public void upgradeGlideTimer()
    {
        if (currentglideTimerUpgrade < maxglideTimerUpgrade && playerStats.puntuantion >= glideTimerUpgradeCost)
        {
            currentglideTimerUpgrade++;
            playerStats.puntuantion -= glideTimerUpgradeCost;
            playerStats.glideMaxTime += glideTimerUpgrade;

            if(currentglideTimerUpgrade != maxglideTimerUpgrade)
            {
                upgradesUI.UpdateGlideSecondsCard();
            }
            else
            {
                upgradesUI.MaxGlideSecondsCard();
            }
        }

    }
}
