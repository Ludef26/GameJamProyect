using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float defaultSpeedMove, defaultSpeedFall, speedGlide, slowGlide, glideTimer;
    private float currentSpeedMove, currentSpeedFall, glideMaxTime;
    public GameObject player;
    private Rigidbody rb;
    private Inputs playerInput;
    private Vector2 inputVector;
    private float glide = 0f;
    private HUDManager hud;

    private void Awake()
    {
        glideMaxTime = glideTimer;
    }

    void Start()
    {
        hud = GameObject.Find("HUD").GetComponent<HUDManager>();
        rb = GetComponent<Rigidbody>();
        playerInput = new Inputs();
        playerInput.PlayerMove.Enable();
    }

    public void Update()
    {
        
    }

    private void FixedUpdate()
    {
        inputVector = playerInput.PlayerMove.MoveAxis.ReadValue<Vector2>();
        glide = playerInput.PlayerMove.Glide.ReadValue<float>();

        //Debug.Log(inputVector);
        inputVector = inputVector.normalized;

        if (glide > 0.1f && glideTimer > 0)
        {
            Debug.Log(glide);
            currentSpeedMove = speedGlide;
            currentSpeedFall = slowGlide;
            glideTimer -= Time.deltaTime;
            hud.UpdateGlideIndicator(glideTimer, glideMaxTime);
        }
        else if (glide > 0.1f && glideTimer <= 0)
        {
            currentSpeedMove = defaultSpeedMove;
            currentSpeedFall = defaultSpeedFall;
            hud.PlayShakeAnimation();
        }
        else
        {
            currentSpeedMove = defaultSpeedMove;
            currentSpeedFall = defaultSpeedFall;
        }

        rb.velocity = transform.up.normalized * currentSpeedFall * -1f + transform.forward.normalized * currentSpeedMove * inputVector.y + transform.right.normalized * currentSpeedMove * inputVector.x;
        /*Debug.DrawRay(transform.position, transform.up.normalized * speedFall * -1f, Color.green);
        Debug.DrawRay(transform.position, transform.forward.normalized * speedFall, Color.red);
        Debug.DrawRay(transform.position, transform.right.normalized * speedFall, Color.blue);*/
    }
}
