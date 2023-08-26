using UnityEngine;

public class SavePlayerValues : MonoBehaviour
{
    [SerializeField] private PlayerMove player;
    [SerializeField] private PlayerUpgrades upgrades;

    public void SetPlayerStats()
    {
        PlayerPrefs.SetFloat("Puntuation", player.puntuantion);
        PlayerPrefs.SetFloat("DashCooldown", player.dashCooldown);
        PlayerPrefs.SetFloat("GlideMaxMove", player.glideMaxMove);
        PlayerPrefs.SetFloat("GlideMaxTimer", player.glideMaxTime);
        PlayerPrefs.SetInt("MaxLifes", player.MaxLifes);

        PlayerPrefs.SetInt("CurrentCooldownUpgrades", upgrades.currentCooldownUpgrades);
        PlayerPrefs.SetInt("CurrentglideMovementUpgrade", upgrades.currentglideMovementUpgrade);
        PlayerPrefs.SetInt("CurrentTimerUpgrades", upgrades.currentglideTimerUpgrade);
        PlayerPrefs.SetInt("CurrentLifesUpgrade", upgrades.currentglideLifesUpgrade);
    }

    public void loadPlayerStats()
    {
        if (!PlayerPrefs.HasKey("Puntuation") || PlayerPrefs.GetInt("newGame") == 1)
        {
            upgrades.currentCooldownUpgrades = 0;
            upgrades.currentglideMovementUpgrade = 0;
            upgrades.currentglideTimerUpgrade = 0;
            upgrades.currentglideLifesUpgrade = 0;

            player.glideMaxTime = 3;
            player.glideMaxMove = 15;
            player.dashCooldown = 2;
            player.MaxLifes = 0;
            player.puntuantion = 0;
            PlayerPrefs.SetInt("newGame", 0);
        }
        else
        {
            upgrades.currentCooldownUpgrades = PlayerPrefs.GetInt("CurrentCooldownUpgrades");
            upgrades.currentglideMovementUpgrade = PlayerPrefs.GetInt("CurrentglideMovementUpgrade");
            upgrades.currentglideTimerUpgrade = PlayerPrefs.GetInt("CurrentTimerUpgrades");
            upgrades.currentglideLifesUpgrade = PlayerPrefs.GetInt("CurrentLifesUpgrade");

            player.puntuantion = PlayerPrefs.GetFloat("Puntuation");
            player.dashCooldown = PlayerPrefs.GetFloat("DashCooldown");
            player.glideMaxMove = PlayerPrefs.GetFloat("GlideMaxMove");
            player.glideMaxTime = PlayerPrefs.GetFloat("GlideMaxTimer");
            player.MaxLifes = PlayerPrefs.GetInt("MaxLifes");
        }
    }

    
}
