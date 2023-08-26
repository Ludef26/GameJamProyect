using UnityEngine;

public class SavePlayerValues : MonoBehaviour
{
    [SerializeField] private PlayerMove player;
    [SerializeField] private PlayerUpgrades upgrades;
    // Start is called before the first frame update

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
        player.puntuantion = PlayerPrefs.GetFloat("Puntuation");
        player.dashCooldown = PlayerPrefs.GetFloat("DashCooldown");
        player.glideMaxMove = PlayerPrefs.GetFloat("GlideMaxMove");
        player.glideMaxTime = PlayerPrefs.GetFloat("GlideMaxTimer");
        player.MaxLifes = PlayerPrefs.GetInt("MaxLifes");

        if (player.newGame)
        {
            upgrades.currentCooldownUpgrades = 0;
            upgrades.currentglideMovementUpgrade = 0;
            upgrades.currentglideTimerUpgrade = 0;
            upgrades.currentglideLifesUpgrade = 0;
        }
        else
        {
            upgrades.currentCooldownUpgrades = PlayerPrefs.GetInt("CurrentCooldownUpgrades");
            upgrades.currentglideMovementUpgrade = PlayerPrefs.GetInt("CurrentglideMovementUpgrade");
            upgrades.currentglideTimerUpgrade = PlayerPrefs.GetInt("CurrentTimerUpgrades");
            upgrades.currentglideLifesUpgrade = PlayerPrefs.GetInt("CurrentLifesUpgrade");
        }
    }

    
}
