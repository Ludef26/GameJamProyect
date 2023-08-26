using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerMove playerStats;
    public float dashCooldownReduction = 0.2f;
    public int maxDashCooldownUpgrade = 5, currentCooldownUpgrades = 0;
    public float dashCooldownCost = 1000;

    public float glideMovementUpgrade = 5.0f;
    public int maxglideMovementUpgrade = 5, currentglideMovementUpgrade = 0;
    public float glideMovementUpgradeCost = 1000;

    public float glideTimerUpgrade = 1.0f;
    public int maxglideTimerUpgrade = 5, currentglideTimerUpgrade = 0;
    public float glideTimerUpgradeCost = 1000;

    public int lifeUpgrade = 1;
    public int maxLifesUpgrade = 2, currentglideLifesUpgrade = 0;
    public float lifeUpgradeCost = 1000;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerMove>();
    }

    public void upgradeDashCooldown()
    {
        if (currentCooldownUpgrades < maxDashCooldownUpgrade && playerStats.puntuantion >= dashCooldownCost)
        {
            currentCooldownUpgrades++;
            playerStats.puntuantion -= dashCooldownCost;
            playerStats.dashCooldown -= dashCooldownReduction;
        }
    }
    public void AddLife()
    {
        if (currentglideLifesUpgrade < maxLifesUpgrade && playerStats.puntuantion >= lifeUpgradeCost)
        {
            currentglideLifesUpgrade++;
            playerStats.puntuantion -= lifeUpgradeCost;
            playerStats.MaxLifes += lifeUpgrade;
        }
    }
    public void upgradeGlideMovement()
    {
        if (currentglideMovementUpgrade < maxglideMovementUpgrade && playerStats.puntuantion >= glideMovementUpgradeCost)
        {
            currentglideMovementUpgrade++;
            playerStats.puntuantion -= glideMovementUpgradeCost;
            playerStats.glideMaxMove += glideMovementUpgrade;
        }
    }
    public void upgradeGlideTimer()
    {
        if (currentglideMovementUpgrade < maxglideTimerUpgrade && playerStats.puntuantion >= glideTimerUpgradeCost)
        {
            currentglideMovementUpgrade++;
            playerStats.puntuantion -= glideTimerUpgradeCost;
            playerStats.glideMaxTime += glideTimerUpgrade;
        }
    }
}
