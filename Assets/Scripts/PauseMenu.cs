using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionsWindow, controlsWindow, backButtonOptions, backButtonControls, resumeButton, initialOptions, counter;
    public EventSystem eventSystem;
    private float options;
    private Inputs playerInput;
    private GameObject hud, player;

    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.SetSelectedGameObject(resumeButton);
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        
    }

    public void DisplayOptionsWindow()
    {
        optionsWindow.SetActive(true);
        eventSystem.SetSelectedGameObject(backButtonOptions);
    }

    public void HideOptionsWindow()
    {
        optionsWindow.SetActive(false);
        eventSystem.SetSelectedGameObject(resumeButton);
    }

    public void DisplayControlsWindow()
    {
        controlsWindow.SetActive(true);
        eventSystem.SetSelectedGameObject(backButtonControls);
    }

    public void HideControlsWindow()
    {
        controlsWindow.SetActive(false);
        eventSystem.SetSelectedGameObject(resumeButton);
    }

    public void BackToGame()
    {
        player.GetComponent<PlayerMove>().StartCoroutine("RecoverControl");
        Time.timeScale = 1;
        gameObject.SetActive(false);
        //initialOptions.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
