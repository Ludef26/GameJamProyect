using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseRotation2 : MonoBehaviour
{
    private GameObject player;
    public float targetXRotation = -52.19f;
    public float rotationMultiplier;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ColliderPlayer")
        {
            StartCoroutine(GradualPlayerRotation());
        } 
    }

    private IEnumerator GradualPlayerRotation()
    {
        while(player.transform.eulerAngles.x > 360 + targetXRotation || player.transform.eulerAngles.x == 0)
        {
            Debug.Log(player.transform.eulerAngles.x);
            player.transform.Rotate(-rotationMultiplier * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.002f);
        }
    }
}
