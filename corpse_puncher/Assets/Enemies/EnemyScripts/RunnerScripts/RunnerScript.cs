using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerScript : EnemyMovement
{
    public int Health = 1;
    public int AttackDamage = 1;
    public GameObject Slash;
    private Vector3 pos;
    public GameObject Corpse;

    void Update()
    {
        pos = gameObject.transform.position;
        if (agent.isStopped == true)
        {
            Invoke("AttackPlayer", timeFirstAttack);
        }
        if (Health <= 0)
        {
            DestroyRunner();
        }
    }

    // TODO:
    // MAKE THE ANIMATION HERE
    // import animator
    // add animator field
    //
    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        if (!alreadyAttacked)
        {
            // print("yoooooooooooo");
            Rigidbody rb = Instantiate(Slash, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rb.AddForce(transform.up * 3f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Corpse, pos, Quaternion.identity);
            }
            Health--;
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
