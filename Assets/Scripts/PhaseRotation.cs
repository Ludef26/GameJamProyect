using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseRotation : MonoBehaviour
{
    private GameObject player;
    public float targetXRotation = -52.19f;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            StartCoroutine(GradualPlayerRotation());
        } 
    }

    private IEnumerator GradualPlayerRotation()
    {
        while(player.transform.eulerAngles.x > 360 + targetXRotation || player.transform.eulerAngles.x == 0)
        {
            Debug.Log(player.transform.eulerAngles.x);
            player.transform.Rotate(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.002f);
        }
    }
}
