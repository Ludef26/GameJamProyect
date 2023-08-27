using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FinalTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject canvasVictory, hud, points, menuButton;
    public EventSystem eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.SetSelectedGameObject(menuButton);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ColliderPlayer")
        {
            canvasVictory.SetActive(true);
            hud.SetActive(false);
            points.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }


}
