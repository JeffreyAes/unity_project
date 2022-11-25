using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterScript : MonoBehaviour
{

    public float raydist = 20f;
    public GameObject SpitterMaterial;
    public float minimumDistance;
    public float Speed;
    public float timeBetweenLaunch;
    public float nextLaunchTime;
    public Transform Player;
    void Start()
    {
        //get player's position here
    }

    void Update()
    {
            // lauching slime code 
        if(Time.time > nextLaunchTime){
            Instantiate(SpitterMaterial, transform.position, Quaternion.identity);
            nextLaunchTime = Time.time + timeBetweenLaunch;
        }

        //rotates direction towards the player:
        if (Player != null){

        transform.LookAt(Player);
        // if the player is (distance) away from spitter it moves the opposite direction
        if (Vector3.Distance(transform.position, Player.position) <  minimumDistance){
            transform.position = Vector3.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }

        }

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
