using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script controls movement of the players model, as well as its graphics and collision physics

    Code in this document adapted from the following source:
    https://www.youtube.com/watch?v=_QajrabyTJc&ab_channel=Brackeys
*/

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 12f;

    public float gravity = -0.4905f;

    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 300f;

    Vector3 velocity;
    bool isGrounded;
    float originalMoveSpeed;

    void Start()
    {
        originalMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Creates small sphere at feet of player and checks for collision

        if (isGrounded && velocity.y < 0) //Stops velocity from gravity from constantly increasing
        {
            velocity.y = -2f;
        }

        if (Input.GetKey("left shift")) //Player sprints whilst holding shift
        {
            moveSpeed = originalMoveSpeed * 1.5f;
        }
        else
        {
            moveSpeed = originalMoveSpeed;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) //Jumps if player is on ground
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity; //Always applies gravity
        controller.Move(velocity * Time.deltaTime);
    }
}
