using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseRotation : MonoBehaviour
{
    private GameObject player;
    public float targetXRotation = 48.5f;
    public float rotationMultiplier;
    private float actualRotation;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            actualRotation = player.transform.eulerAngles.x;
            StartCoroutine(GradualPlayerRotation());
        } 
    }
     
    private IEnumerator GradualPlayerRotation()
    {
        while(player.transform.eulerAngles.x >= 1.0f)
        {
            Debug.Log(actualRotation);
            player.transform.Rotate(rotationMultiplier * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.002f);
        }
    }
}
