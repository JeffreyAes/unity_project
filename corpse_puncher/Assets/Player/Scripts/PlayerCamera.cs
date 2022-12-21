using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    //mouse sens
    [SerializeField] private float mouseSens = 1000f;
    private float xRot = 0f;

    public Transform playerBody;

    void Start(){
        //hides cursor on game start
        Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        //look up and down
        xRot -= mouseY;
        xRot = Math.Clamp(xRot, -90f, 90f);

        //look left and right (rotates the body)
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
