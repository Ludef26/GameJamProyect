using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsWindow : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject backButton, playButton;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.SetSelectedGameObject(backButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        eventSystem.SetSelectedGameObject(playButton);
    }
}
