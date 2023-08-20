using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedFall;
    public float speedMove;
    Vector3 direction;
    public GameObject cubo;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Mando
        /*float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        */

        // Teclado
        bool left = Input.GetKey("left");
        bool right = Input.GetKey("down");
        bool up = Input.GetKey("up");
        bool down = Input.GetKey("down");

        if (Input.GetKey("left"))
        {
            direction = new Vector3(-1.0f, 0.0f, 0.0f).normalized;
            cubo.transform.Translate(direction * speedMove * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            direction = new Vector3(1.0f, 0.0f, 0.0f).normalized;
            cubo.transform.Translate(direction * speedMove * Time.deltaTime);
        }
        if (Input.GetKey("up"))
        {
            direction = new Vector3(0.0f, 0.0f, 1.0f).normalized;
            cubo.transform.Translate(direction * speedMove * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            direction = new Vector3(0.0f, 0.0f, -1.0f).normalized;
            cubo.transform.Translate(direction * speedMove * Time.deltaTime);
        }


    }

    void FixedUpdate()
    {
        cubo.transform.Translate(new Vector3(0.0f, -1.0f * speedFall * Time.deltaTime, 0.0f));
    }
}
