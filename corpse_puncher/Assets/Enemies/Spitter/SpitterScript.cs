using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterScript : MonoBehaviour
{

    public float raydist = 20f;
    void Start()
    {
        //get player's position here
    }

    void Update()
    {
        //update player's position here

        RaycastHit hit; //hit is of type RaycastHit
        //  Physics.Raycast(ORIGIN,             DIRECTION,                    RAYCASTHIT,DISTANCE)
        if (Physics.Raycast(transform.position, gameObject.transform.forward, out hit, raydist))
        {
            Debug.Log("object name is " + hit.collider.name);
        }

    }

    void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, gameObject.transform.forward * raydist, Color.green);
    }
}
