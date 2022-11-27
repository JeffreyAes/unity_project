using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private int jumps = 1;
    public GameObject kick;
    Rigidbody m_Rigidbody;
    private float horizontalSpeed = 2.0f;
    public float airTime = 0.1f;
    private float jumpCap;


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
            jumpCap = Time.time + airTime;
        }
        if (Input.GetKeyUp("space"))
        {
            jumps--;
            print("released jump");
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
        if (Input.GetKey("space"))
        {
            if (jumps > 0)
            {
                if (Time.time < jumpCap)
                {
                    m_Rigidbody.velocity = new Vector3(0,0,0);
                    m_Rigidbody.AddForce(0, 10, 0, ForceMode.VelocityChange);
                }
            }

        }
        


        if (m_Rigidbody.velocity.y < 0)
        {
            // if(m_Rigidbody.velocity.y < -100f){
            //     m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x,-100,m_Rigidbody.velocity.z);
            // }
            m_Rigidbody.AddForce(0, m_Rigidbody.velocity.y * 1.5f, 0, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        jumps = 2;
    }

}
