using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchCollider : MonoBehaviour
{
    public GameObject objectToOpen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ColliderPlayer")
        {
            objectToOpen.GetComponent<Animator>().enabled = true;
        }
    }
}
