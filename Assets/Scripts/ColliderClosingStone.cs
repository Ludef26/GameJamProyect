using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderClosingStone : MonoBehaviour
{
    public GameObject objectToOpen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            objectToOpen.GetComponent<Animator>().enabled = true;
        }
    }
}
