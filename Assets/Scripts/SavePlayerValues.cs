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
        PlayerPrefs.SetFloat("SpeedGlide", player.speedGlide);
        PlayerPrefs.SetFloat("GlideTimer", player.glideTimer);
        PlayerPrefs.SetInt("Lifes", player.lifes);

        PlayerPrefs.SetInt("CurrentCooldownUpgrades", upgrades.currentCooldownUpgrades);
        PlayerPrefs.SetInt("CurrentglideMovementUpgrade", upgrades.currentglideMovementUpgrade);
        PlayerPrefs.SetInt("CurrentTimerUpgrades", upgrades.currentglideTimerUpgrade);
        PlayerPrefs.SetInt("CurrentLifesUpgrade", upgrades.currentglideLifesUpgrade);
    }

    public void loadPlayerStats()
    {
        player.puntuantion = PlayerPrefs.GetFloat("Puntuation");
        player.dashCooldown = PlayerPrefs.GetFloat("DashCooldown");
        player.speedGlide = PlayerPrefs.GetFloat("SpeedGlide");
        player.glideTimer = PlayerPrefs.GetFloat("GlideTimer");
        player.lifes = PlayerPrefs.GetInt("Lifes");

        upgrades.currentCooldownUpgrades = PlayerPrefs.GetInt("CurrentCooldownUpgrades");
        upgrades.currentglideMovementUpgrade = PlayerPrefs.GetInt("CurrentglideMovementUpgrade");
        upgrades.currentCooldownUpgrades = PlayerPrefs.GetInt("currentglideTimerUpgrade");
        upgrades.currentglideMovementUpgrade = PlayerPrefs.GetInt("currentglideLifesUpgrade");
    }

    
}
