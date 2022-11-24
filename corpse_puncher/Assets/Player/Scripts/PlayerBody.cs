using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: make script names readable
public class PlayerBody : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 100f;
    private float horizontalSpeed = 2.0f;
    [SerializeField] private int jumps = 5;
    public GameObject kick;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        


        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        rotation *= Time.deltaTime;


        //TODO: change from .transform.Translate()?
        //into something that doesn't need deceleration
        if (Input.GetKey("w"))
        {
            m_Rigidbody.transform.Translate(0, 0, translation);
        }
        if (Input.GetKey("s"))
        {
            m_Rigidbody.transform.Translate(0, 0, translation);
        }
        if (Input.GetKey("a"))
        {
            m_Rigidbody.transform.Translate(strafe, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            m_Rigidbody.transform.Translate(strafe, 0, 0);
        }

        if (Input.GetKeyDown("space"))
        {
            jumps--;
            if (jumps > 0)
            {
                // m_Rigidbody.AddForce(0, 15, 0, ForceMode.VelocityChange);
                m_Rigidbody.velocity = new Vector3(0, 11, 0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            m_Rigidbody.velocity = new Vector3(0, -50, 0);
        }

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
        // print(transform.localEulerAngles);



        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(kick, gameObject.transform);
        }

    }

    void FixedUpdate()
    {
        if (m_Rigidbody.velocity.y < 0)
        {
            m_Rigidbody.AddForce(0, m_Rigidbody.velocity.y * 1.5f, 0, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        jumps = 5;
    }

}
