using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseRotation : MonoBehaviour
{
    private GameObject player;
    public float targetXRotation = 48.5f;
    public float rotationMultiplier;
    private float actualRotation;
    private bool isRotating = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ColliderPlayer")
        {
            actualRotation = player.transform.eulerAngles.x;
            isRotating = true;
        } 
    }

    private void FixedUpdate()
    {
        if (isRotating)
        {
            player.transform.Rotate(-rotationMultiplier * Time.deltaTime, 0, 0);
            if (player.transform.eulerAngles.x <= 360 + targetXRotation)
            {
                isRotating = false;
            }
        }
    }
}
