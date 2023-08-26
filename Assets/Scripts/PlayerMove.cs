using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float defaultSpeedMove, defaultSpeedFall, slowGlide;
    private float currentSpeedMove, currentSpeedFall, glideTimer, speedGlide;
    public float glideMaxTime, glideMaxMove;
    public GameObject player, canvas, hudGO;
    private Rigidbody rb;
    public Inputs playerInput;
    private Vector2 inputVector;
    private float glide = 0f, options;
    private float dash = 0f;
    private HUDManager hud;
    public float dashTime;
    private bool dashing = false, normalDash;
    public float auxDashTime;
    public float dashCooldown;
    private float auxdashCooldown;
    private bool onCooldown;
    public float normalDashPower, downDashPower;
    public float puntuantion = 0;
    private SavePlayerValues PlayerStats;
    public int lifes = 1;
    public int MaxLifes = 0;
    private AudioSource audioSource;
    public AudioClip dashFx;
    public GameObject model;
    private Animator modelAnimator;
    public bool newGame;
    private void Awake()
    {
        
    }

    void Start()
    {
        hud = GameObject.Find("HUD").GetComponent<HUDManager>();
        hudGO = GameObject.Find("HUD");
        rb = GetComponent<Rigidbody>();
        playerInput = new Inputs();
        playerInput.PlayerMove.Enable();
        auxdashCooldown = 0;
        PlayerStats = GetComponent<SavePlayerValues>();
        PlayerStats.loadPlayerStats();
        audioSource = GetComponent<AudioSource>();
        modelAnimator = model.GetComponent<Animator>();
        if (newGame)
        {
            glideMaxTime = 3;
            glideMaxMove = 15;
            dashCooldown = 2;
            MaxLifes = 0;
        }
        glideTimer = glideMaxTime;
        speedGlide = glideMaxMove;
        auxDashTime = dashTime;
        lifes = MaxLifes;
    }

    public void Update()
    {
        options = playerInput.PlayerMove.Pause.ReadValue<float>();

        if (options > 0.1f)
        {
            playerInput.PlayerMove.Disable();
            Time.timeScale = 0;
            hudGO.SetActive(false);
            canvas.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        inputVector = playerInput.PlayerMove.MoveAxis.ReadValue<Vector2>();
        glide = playerInput.PlayerMove.Glide.ReadValue<float>();
        dash = playerInput.PlayerMove.Dash.ReadValue<float>();

        if(inputVector.x > 0)
        {
            modelAnimator.SetBool("LeftMove", false);
            modelAnimator.SetBool("RightMove", true);
        } else if (inputVector.x < 0) 
        {
            modelAnimator.SetBool("LeftMove", true);
            modelAnimator.SetBool("RightMove", false);
        } else
        {
            modelAnimator.SetBool("LeftMove", false);
            modelAnimator.SetBool("RightMove", false);
        }
        //Debug.Log(inputVector);
        inputVector = inputVector.normalized;

        if (glide > 0.1f && glideTimer > 0)
        {
            modelAnimator.SetBool("Glide", true);
            if (inputVector.x > 0)
            {
                modelAnimator.SetBool("GlideLeft", false);
                modelAnimator.SetBool("GlideRight", true);
            }
            else if (inputVector.x < 0)
            {
                modelAnimator.SetBool("GlideLeft", true);
                modelAnimator.SetBool("GlideRight", false);
            }
            else
            {
                modelAnimator.SetBool("GlideLeft", false);
                modelAnimator.SetBool("GlideRight", false);
                modelAnimator.SetBool("Glide", true);
            }
            // Debug.Log(glide);
            currentSpeedMove = speedGlide;
            currentSpeedFall = slowGlide;
            glideTimer -= Time.deltaTime;
            hud.UpdateGlideIndicator(glideTimer, glideMaxTime);
            Debug.Log(glideTimer);
        }
        else if (glide > 0.1f && glideTimer <= 0)
        {
            modelAnimator.SetBool("Glide", false);
            modelAnimator.SetBool("GlideRight", false);
            modelAnimator.SetBool("GlideLeft", false);
            Debug.Log("entra2");
            currentSpeedMove = defaultSpeedMove;
            currentSpeedFall = defaultSpeedFall;
            hud.PlayShakeAnimation();
        }
        else
        {
            modelAnimator.SetBool("Glide", false);
            modelAnimator.SetBool("GlideRight", false);
            modelAnimator.SetBool("GlideLeft", false);
            currentSpeedMove = defaultSpeedMove;
            currentSpeedFall = defaultSpeedFall;
        }

        if(dash > 0.1f && !dashing && !onCooldown)
        {
            audioSource.PlayOneShot(dashFx);
            if (inputVector.x != 0f || inputVector.y != 0f)
            {
                normalDash = true;

            }
            else
            {
                normalDash = false;
            }
            dashing = true;
        }

        if (dashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime < 0.0f)
            {
                dashing = false;
                dashTime = auxDashTime;
                onCooldown = true;
            }
            if (normalDash)
            {
                rb.velocity = transform.up.normalized * currentSpeedFall * -1f + transform.forward.normalized * normalDashPower * inputVector.y + transform.right.normalized * normalDashPower * inputVector.x;
            }
            else
            {
                rb.velocity = transform.up.normalized * downDashPower * -1f + transform.forward.normalized * currentSpeedMove * inputVector.y + transform.right.normalized * currentSpeedMove * inputVector.x;
            }
        }
        else {
            rb.velocity = transform.up.normalized * currentSpeedFall * -1f + transform.forward.normalized * currentSpeedMove * inputVector.y + transform.right.normalized * currentSpeedMove * inputVector.x;
        }
        /*Debug.DrawRay(transform.position, transform.up.normalized * speedFall * -1f, Color.green);
        Debug.DrawRay(transform.position, transform.forward.normalized * speedFall, Color.red);
        Debug.DrawRay(transform.position, transform.right.normalized * speedFall, Color.blue);*/
        if (onCooldown)
        {
            auxdashCooldown += Time.deltaTime;
            hud.UpdateDashIndicator(dashCooldown, auxdashCooldown);
            if (auxdashCooldown >= dashCooldown)
            {
                auxdashCooldown = 0;
                onCooldown = false;
                hud.PlayBlinkAnimation();
            }
        }

        puntuantion += transform.up.normalized.magnitude;
        //Debug.Log(puntuantion);
    }

    public IEnumerator RecoverControl()
    {
        hudGO.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        playerInput.PlayerMove.Enable();
    }
}
