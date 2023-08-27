using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseRotation2 : MonoBehaviour
{
    private GameObject player;
    public float targetXRotation = 0f;
    public float rotationMultiplier;
    private bool isRotating = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ColliderPlayer")
        {
            isRotating = true;
        } 
    }
    private void FixedUpdate()
    {
        if (isRotating)
        {
            Debug.Log("entra a isRotating");
            player.transform.Rotate(rotationMultiplier * Time.deltaTime, 0, 0);
            if (player.transform.eulerAngles.x > 359)
            {
                Debug.Log("entra a 2do if");
                isRotating = false;
            }
        }
    }
}
