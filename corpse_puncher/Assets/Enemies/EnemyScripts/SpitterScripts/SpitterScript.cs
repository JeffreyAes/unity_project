using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterScript : MonoBehaviour
{

    public float raydist = 20f;
    public GameObject Acid;
    [SerializeField] private float minimumDistance = 5f;
    [SerializeField] private float maxDistance = 100f;
    public float Speed = 10f;
    public float timeBetweenLaunch = 10f;
    public float nextLaunchTime = 10f;
    private GameObject Player;
    private Transform PlayerLocation;

    public int Health = 1;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerLocation = Player.transform;
    }

    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        Quaternion rot = Quaternion.Euler(transform.position.x, transform.position.y, transform.position.z);
        // lauching slime code 

        //rotates direction towards the player:
        if (Player != null)
        {
            if (Vector3.Distance(transform.position, PlayerLocation.position) < maxDistance)
            {
                transform.LookAt(PlayerLocation);
                if (Time.time > nextLaunchTime)
                {
                    Instantiate(Acid, pos, Quaternion.identity);
                    nextLaunchTime = Time.time + timeBetweenLaunch;
                }
            }
            // if the player is (distance) away from spitter it moves the opposite direction
            if (Vector3.Distance(transform.position, PlayerLocation.position) < minimumDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerLocation.position, Speed * -1 * Time.deltaTime);
            }
            else
            {
                transform.position = transform.position;
            }

        }

        //update player's position here

        RaycastHit hit; //hit is of type RaycastHit
        //  Physics.Raycast(ORIGIN,             DIRECTION,                    RAYCASTHIT,DISTANCE)
        if (Physics.Raycast(transform.position, gameObject.transform.forward, out hit, raydist))
        {
            // Debug.Log("object name is " + hit.collider.name);
        }

    }

    void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, gameObject.transform.forward * raydist, Color.green);
    }
}
