﻿using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine; //dyrektywa using/biblioteka

// public - modyfikator dostępu
public class PlayerMovement : MonoBehaviour // klasa z której nasz skrypt dziedziczy
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float raycastDistance = 0.6f;

    [SerializeField]
    private string playerName = "Mario";

    private bool isAlive = true;

    private bool isGrounded;

    private Vector2 moveInput;

    [SerializeField]
    private Rigidbody rb;

    public void SetSpeed(float newSpeed)
    {
        Debug.Log("cos");

        moveSpeed = newSpeed;

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    private void Update()
    {
        moveInput = GetInput();
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private Vector2 GetInput()
    {
        var inputX = Input.GetAxis("Horizontal"); //zwraca wartość między -1 a 1
        var inputY = Input.GetAxis("Vertical");

        return new Vector2(inputX, inputY);
    }

    private bool CheckIfIsGrounded()
    {
        var ground = Physics.Raycast(transform.position, Vector3.down, raycastDistance);
        return ground;
    }

    private void Move()
    {
        transform.position += (Vector3) moveInput *Time.deltaTime * moveSpeed; //porusznanie sie za pomocą transform
    }

    private void Jump()
    {
        if (CheckIfIsGrounded())
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
}