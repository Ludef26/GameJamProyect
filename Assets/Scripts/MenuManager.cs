using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsWindow, backButton, playButton;
    public EventSystem eventSystem;

    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    public void DisplayOptionsWindow()
    {
        optionsWindow.SetActive(true);
        eventSystem.SetSelectedGameObject(backButton);
    }

    public void HideOptionsWindow()
    {
        optionsWindow.SetActive(false);
        eventSystem.SetSelectedGameObject(playButton);
    }

    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
