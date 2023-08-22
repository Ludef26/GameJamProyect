using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedMove, speedFall;
    public GameObject player;
    private Rigidbody rb;
    private Inputs playerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new Inputs();
        playerInput.PlayerMove.Enable();
    }

    public void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInput.PlayerMove.MoveAxis.ReadValue<Vector2>();
        Debug.Log(inputVector);
        inputVector = inputVector.normalized;

        //Vector3 newPosition = new Vector3(transform.position.x + inputVector.x * speedMove * Time.deltaTime, transform.position.y - speedFall * Time.deltaTime, transform.position.z + inputVector.y * speedMove * Time.deltaTime);
        //rb.MovePosition(newPosition);
        rb.velocity = new Vector3 (inputVector.x * speedMove, -speedFall, inputVector.y * speedMove);
    }
}
