using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsWindow, controlsWindow, backButtonOptions, backButtonControls, playButton, clickGO;
    public EventSystem eventSystem;

    private void Awake()
    {
        StartCoroutine(DelayClickSound());
    }
    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    public void DisplayOptionsWindow()
    {
        optionsWindow.SetActive(true);
        eventSystem.SetSelectedGameObject(backButtonOptions);
    }

    public void HideOptionsWindow()
    {
        optionsWindow.SetActive(false);
        eventSystem.SetSelectedGameObject(playButton);
    }

    public void DisplayControlsWindow()
    {
        controlsWindow.SetActive(true);
        eventSystem.SetSelectedGameObject(backButtonControls);
    }

    public void HideControlsWindow()
    {
        controlsWindow.SetActive(false);
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

    private IEnumerator DelayClickSound()
    {
        yield return new WaitForSeconds(0.2f);
        clickGO.GetComponent<AudioSource>().enabled = true;
    }
}
