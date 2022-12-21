using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public GameObject Runner;
    public GameObject Player;
    private int SlashDamage;
    private int PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        Runner = GameObject.FindWithTag("Runner");
        SlashDamage = Runner.GetComponent<RunnerScript>().AttackDamage;
        Player = GameObject.FindWithTag("Player");
        PlayerHealth = Player.GetComponent<PlayerHealth>().currentHealth;
        Invoke("DestroySlash", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(Runner.position, transform.position) >= SlashRange)
        // {
        //     DestroySlash();
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print(PlayerHealth);
            if (PlayerHealth > 0)
            {
            other.gameObject.GetComponent<PlayerHealth>().currentHealth -= SlashDamage;
            
            }
            DestroySlash();
        }
    }

    void DestroySlash()
    {
        Destroy(gameObject);
    }
}
