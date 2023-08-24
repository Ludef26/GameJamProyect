using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerMove playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerMove>();
    }

    public void upgradeDashCooldown()
    {
        if (playerStats.dashCooldown > 1.0f)
        {
            playerStats.dashCooldown -= 0.2f;
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
