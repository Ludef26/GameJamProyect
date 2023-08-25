using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerMove playerStats;
    public float dashCooldownReduction = 0.2f;
    public int maxDashCooldownUpgrade = 5, currentCooldownUpgrades = 0;
    public float dashCooldownCost = 1000;
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
        if (playerStats.lifes < 2)
        {
            playerStats.lifes += 1;
        }
    }
    public void upgradeGlideMovement()
    {
        if (playerStats.speedGlide < 40)
        {
            playerStats.speedGlide += 5;
        }
    }
    public void upgradeGlideTimer()
    {
        if (playerStats.glideTimer < 8)
        {
            playerStats.glideTimer += 1;
        }
    }
}
