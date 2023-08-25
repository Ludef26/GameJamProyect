using UnityEngine;

public class SavePlayerValues : MonoBehaviour
{
    [SerializeField] private PlayerMove player;
    [SerializeField] private PlayerUpgrades upgrades;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void SetPlayerStats()
    {
        PlayerPrefs.SetFloat("Puntuation", player.puntuantion);
        PlayerPrefs.SetFloat("DashCooldown", player.dashCooldown);
        PlayerPrefs.SetFloat("CurrentCooldownUpgrades", upgrades.currentCooldownUpgrades);
    }

    public void loadPlayerStats()
    {
        player.puntuantion = PlayerPrefs.GetFloat("Puntuation");
        player.dashCooldown = PlayerPrefs.GetFloat("DashCooldown");
        upgrades.currentCooldownUpgrades = PlayerPrefs.GetInt("CurrentCooldownUpgrades");
    }

    
}
