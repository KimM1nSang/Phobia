using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public PlayerInput input;
    public float speed = 12f;
    public float gravity = -10f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        float x = input.rightMove;
        float z = input.frontMove;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        //이동
        controller.Move(move * speed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;

        //중력
        controller.Move(velocity * Time.deltaTime);
    }
}
