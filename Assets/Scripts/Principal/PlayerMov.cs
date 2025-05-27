using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Camera playerCamera;
    public float speed;
    public float speedfx = 6f;
    public float runspeed;
    public float jump = 1f;
    
    public float TurnSmoothTime = 0.1f;
    public float TurnSmoothVelocity;

    public Transform groundCheck;
    bool isGrounded;
    public float groundDistance = 0.4f;
    public float gravity = 16f;
    public float yspeed;
    Vector3 velocity;
    public LayerMask groundMask;

    void Start()
    {       
        runspeed = speedfx * 2;
    }

    void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {            
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            if (isRunning)
            {
                speed = runspeed;
            }
            else 
            {
                speed = speedfx;
            }

            Vector3 MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(MoveDir.normalized * speed * Time.deltaTime);
           
        }

        //gravidade
        velocity.y -= (gravity * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
           velocity.y = 0;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y += jump;
        }
         
        //fazedor de movimento y
        controller.Move ((velocity * 1.2f) * Time.deltaTime);
    }
}



