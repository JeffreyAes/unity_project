using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private int jumps = 1;
    public GameObject kick;

    public float gravity = -20f;
    private Vector3 velocity;

    //receives a transform of a groundCheck object
    public Transform groundCheck;
    //size of the checkSphere
    [SerializeField] private float groundDist = 0.5f;
    //checkSphere is looking for this
    public LayerMask groundMask;
    //is grounded
    public bool isGrounded;

    public CharacterController characterController;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;

        //for checking grounding
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (isGrounded && velocity.y < -2f)
        {
            print("I am grounded");
            velocity.y = -2f;
        }
        else
        {
            //if in air, be affected by a downward force
            print("I am airborne");
            velocity.y += gravity * 5 * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        //gets x and z vectors from ranges -1 to 1
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //uses x and z vectors (x,0,0) and (0,0,z)
        //and adds them for a cumulative transform
        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = 30;
        }






        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(kick, gameObject.transform);
        }
    }
}