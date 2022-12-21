using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    //mouse sens
<<<<<<< HEAD
    [SerializeField] float vSens = 2.0f;
    public GameObject punch;
    public float raydist = 10f;
    float v = 0;
    void Start()
    {
=======
    [SerializeField] private float mouseSens = 1000f;
    private float xRot = 0f;

    public Transform playerBody;

    void Start(){
>>>>>>> main
        //hides cursor on game start
        Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
<<<<<<< HEAD
        if (!PauseScreen.isPaused)
        {

            v += vSens * Input.GetAxis("Mouse Y");
            v = Math.Clamp(v, -90, 90);

            transform.localEulerAngles = new Vector3(v * -1, 0, 0);



            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(punch, gameObject.transform);
            }
        }
        //


        //raycast test
        // RaycastHit hit; //hit is of type RaycastHit
        // if (Physics.Raycast(transform.position, gameObject.transform.forward, out hit, raydist))
        // {
        //     Debug.Log("object name is " + hit.collider.name);
        // }
=======
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        //look up and down
        xRot -= mouseY;
        xRot = Math.Clamp(xRot, -90f, 90f);
>>>>>>> main

        //look left and right (rotates the body)
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
