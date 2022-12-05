using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed*Time.deltaTime);
        
        if (Vector3.Distance(transform.position, target.position) > maxDistance)
        {
            Enemybody.velocity = (transform.forward) * speed * Time.fixedDeltaTime;
        }
        if (Vector3.Distance(transform.position, target.position) <= minDistance)
        {
            Enemybody.velocity = Enemybody.velocity * 0.15f * Time.fixedDeltaTime;
        }
    }
}
