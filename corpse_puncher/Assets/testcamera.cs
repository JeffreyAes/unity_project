using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcamera : MonoBehaviour
{

    //mouse sens
    [SerializeField] float verticalSpeed = 2.0f;
    public GameObject punch;
    

    float v = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        v += verticalSpeed * Input.GetAxis("Mouse Y");
        v = Math.Clamp(v, -90, 90);

        transform.localEulerAngles = new Vector3(v * -1, 0, 0);
        // print("My camera Y: " + transform.forward);

        if (Input.GetKeyDown(KeyCode.E))
        {
            //creates a new object 'punch' at this current object's location
            Instantiate(punch, gameObject.transform);
        }
    }
}
