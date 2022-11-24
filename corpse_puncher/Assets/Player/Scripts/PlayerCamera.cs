using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    //mouse sens
    [SerializeField] float vSens = 2.0f;
    public GameObject punch;
    float v = 0;

    void Update()
    {
        v += vSens * Input.GetAxis("Mouse Y");
        v = Math.Clamp(v, -90, 90);

        transform.localEulerAngles = new Vector3(v * -1, 0, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(punch, gameObject.transform);
        }
    }
}
