using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{



    Camera cam;
    public  Transform target;
    private Transform bullet;
    private NavMeshHit hit;
    public NavMeshAgent agent;
    private bool blocked = false;
    private Rigidbody Enemybody;
    public float rotationSpeed = 3.0f;
    public float speed = 10.0f;

    public float timeBetweenAttacks;
    public float timeFirstAttack;
    public bool alreadyAttacked = false;

    public float minDistance = 1f;
    private float maxDistance = 100.0f;
    public int AttackDamage = 1;


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
        if (Vector3.Distance(transform.position, target.position) < maxDistance)
        {
            transform.LookAt(target);
            blocked = NavMesh.Raycast(transform.position, target.position, out hit, NavMesh.AllAreas);
            Debug.DrawLine(transform.position, target.position, blocked ? Color.red : Color.green);
            agent.SetDestination(target.position);

        }
        if (Vector3.Distance(transform.position, target.position) < minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * -1 * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance+0.1)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }

    }

    

    void FixedUpdate()
    {

    }



}
