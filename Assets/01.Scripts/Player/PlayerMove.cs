using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -10f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private PlayerInput input;

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        input = PlayerInput.instance;
    }
    void Update()
    {

        if (!GameManager.instance.canMove) return;

        float x = input.rightMove;
        float z = input.frontMove;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -9.8f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        //이동
        controller.Move(move * speed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;

        //중력
        controller.Move(velocity * Time.deltaTime);
    }
}
