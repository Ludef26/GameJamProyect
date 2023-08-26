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

        upgrades.currentCooldownUpgrades = PlayerPrefs.GetInt("CurrentCooldownUpgrades");
        upgrades.currentglideMovementUpgrade = PlayerPrefs.GetInt("CurrentglideMovementUpgrade");
        upgrades.currentCooldownUpgrades = PlayerPrefs.GetInt("currentglideTimerUpgrade");
        upgrades.currentglideMovementUpgrade = PlayerPrefs.GetInt("currentglideLifesUpgrade");
    }

    
}
