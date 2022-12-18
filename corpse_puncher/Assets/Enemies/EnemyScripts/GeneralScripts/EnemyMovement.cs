using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{



    Camera cam;
    private Transform target;
    private NavMeshHit hit;
    public NavMeshAgent agent;
    private bool blocked = false;
    private Rigidbody Enemybody;
    public float rotationSpeed = 3.0f;
    public float speed = 10.0f;

    private float minDistance = 3.0f;
    private float maxDistance = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        Enemybody = GetComponent<Rigidbody>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        blocked = NavMesh.Raycast(transform.position, target.position, out hit, NavMesh.AllAreas);
        Debug.DrawLine(transform.position, target.position, blocked ? Color.red : Color.green);
        // agent.SetDestination(target.position);
        if (!blocked)
            agent.SetDestination(hit.position);
        else {
        agent.SetDestination(target.position);
        }
        if (Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            agent.isStopped = true;
        }
        else{
            agent.isStopped = false;
        }
        
    }

    void FixedUpdate()
    {
        // transform.LookAt(target);

        // if (Vector3.Distance(transform.position, target.position) > maxDistance)
        // {
        //     Enemybody.velocity = (transform.forward) * speed * Time.fixedDeltaTime;
        // }
        // if (Vector3.Distance(transform.position, target.position) <= minDistance)
        // {
        //     Enemybody.velocity = Enemybody.velocity * 0.15f * Time.fixedDeltaTime;
        // }
    }



}
