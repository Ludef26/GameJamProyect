using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    private Light light;
    public float speedMultiplier;
    private bool bajadaIntensidad = true;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if(bajadaIntensidad == true)
        {
            light.intensity -= speedMultiplier * Time.deltaTime;
            if(light.intensity <= 0)
            {
                bajadaIntensidad = false;
            }
        }
        if (bajadaIntensidad == false)
        {
            light.intensity += speedMultiplier * Time.deltaTime;
            if (light.intensity >= 30)
            {
                bajadaIntensidad = true;
            }
        }
    }
}
