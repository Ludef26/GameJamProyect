using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float LaserCooldown;
    private float AuxLaserCooldown;
    private bool Invisible = false;
    private float Alfa = 1f;
    // Start is called before the first frame update
    void Start()
    {
        AuxLaserCooldown = LaserCooldown;
        GetComponent<Renderer>().material.color = new Color(0.792f, 0.102f, 0.721f, Alfa);
    }

    // Update is called once per frame
    void Update()
    {
     
        if (!Invisible)
        {
            Alfa -= Time.deltaTime * LaserCooldown;
            GetComponent<Renderer>().material.color = new Color(0.792f, 0.102f, 0.721f, Alfa);
            if (Alfa <= 0)
            {
                Invisible = !Invisible;
            }
        }
        else
        {      
            Alfa += Time.deltaTime * LaserCooldown;
            GetComponent<Renderer>().material.color = new Color(0.792f, 0.102f, 0.721f, Alfa);
            if (Alfa >= 1)
            {
                Invisible = !Invisible;
            }
        }

    }
}