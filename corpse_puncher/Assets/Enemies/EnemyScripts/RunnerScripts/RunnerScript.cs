using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerScript : EnemyMovement
{
    public int Health = 1;
    public int AttackDamage = 1;
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
            Invoke("AttackPlayer", timeFirstAttack);
        }
        if (Health <= 0)
        {
            DestroyRunner();
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Punch")
        {
            Health --;
        }
    }

    void DestroyRunner()
    {
        Destroy(gameObject);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
