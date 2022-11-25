using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    //mouse sens
    [SerializeField] float vSens = 2.0f;
    public GameObject punch;
    public float raydist = 10f;
    float v = 0;
    void Start(){
        //hides cursor on game start
        Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        v += vSens * Input.GetAxis("Mouse Y");
        v = Math.Clamp(v, -90, 90);

        transform.localEulerAngles = new Vector3(v * -1, 0, 0);

        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(punch, gameObject.transform);
        }
        //


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
