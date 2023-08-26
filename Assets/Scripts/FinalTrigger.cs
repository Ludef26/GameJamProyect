using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ColliderPlayer")
        {
            Debug.Log("has ganado");
            // poner el hud de victoria
        }
    }
}
