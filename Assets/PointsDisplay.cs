using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
    private PlayerMove playerScript;
    private TMP_Text pointsDisplay;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMove>();
        pointsDisplay = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        pointsDisplay.text = playerScript.puntuantion.ToString() + " P";
    }
}
