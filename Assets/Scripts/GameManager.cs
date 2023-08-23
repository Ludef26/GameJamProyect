using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene currentScene;
    private SavePlayerValues playerStats;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        playerStats = GameObject.Find("Player").GetComponent<SavePlayerValues>();
    }

    public void RestartLevel()
    {
        playerStats.SetPlayerStats();
        SceneManager.LoadScene(currentScene.name);
    }
}
