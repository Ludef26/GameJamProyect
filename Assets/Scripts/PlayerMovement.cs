using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedFall;
    float auxSF;
    public float speedMove;
    public float speedDash = 100.0f;
    public float slowTime = 1.0f;
    public float slowTimeSpeed;
    bool jumping = false;
    Vector3 direction;
    public GameObject cubo;
    private Rigidbody rb;
    private Inputs playerInput;

    // Start is called before the first frame update
    void Start()
    {
        auxSF = speedFall;
        rb = GetComponent<Rigidbody>();
        playerInput = new Inputs();
        playerInput.PlayerMove.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        // Mando
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0.0f, vertical).normalized;
        cubo.transform.Translate(direction * speedMove * Time.deltaTime);

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

        if (Input.GetKeyDown("space") && !jumping)
        {
            jumping = true;
            speedFall = slowTimeSpeed;
        }
        if (Input.GetKeyUp("space") && jumping)
        {
            jumping = false;
            speedFall = auxSF;
        }

        if (jumping)
        {
            slowTime -= Time.deltaTime;
            if(slowTime <= 0.0f)
            {
                jumping = false;
                speedFall = auxSF;
            }
        }

        cubo.transform.Translate(new Vector3(0.0f, -1.0f * speedFall * Time.deltaTime, 0.0f));
    }
}
