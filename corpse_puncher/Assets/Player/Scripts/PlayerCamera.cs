using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    //mouse sens
    [SerializeField] private float mouseSens = 1000f;

    public Transform playerBody;

    float xRot = 0f;


    public GameObject punch;
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

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(punch, gameObject.transform);
        }


        //raycast test
        // RaycastHit hit; //hit is of type RaycastHit
        // if (Physics.Raycast(transform.position, gameObject.transform.forward, out hit, raydist))
        // {
        //     Debug.Log("object name is " + hit.collider.name);
        // }

    }

    // void OnDrawGizmos()
    // {
    //     Debug.DrawRay(transform.position, gameObject.transform.forward * raydist, Color.green);
    // }
}
