using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerScript : EnemyMovement
{
    public float Health = 100f;
    public float AttackDamage = 12f;
    public GameObject Slash;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isStopped == true)
        {
            AttackPlayer();
        }
    }


    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        if (!alreadyAttacked)
        {
            // print("yoooooooooooo");
            Rigidbody rb = Instantiate(Slash, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward *10f, ForceMode.Impulse);
            rb.AddForce(transform.up *3f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
