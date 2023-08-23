using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerValues : MonoBehaviour
{
    [SerializeField] private PlayerMove player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void SetPlayerStats()
    {
        PlayerPrefs.SetFloat("Puntuation", player.puntuantion);
    }

    public void loadPlayerStats()
    {
        player.puntuantion = PlayerPrefs.GetFloat("Puntuation");
    }

    
}
