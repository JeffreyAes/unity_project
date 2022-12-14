using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    private Vector3 forward;
    private Rigidbody rg_acid;
    private GameObject Player;
    public float speed =10f;
    private int counter = 0;
    public int AttackDamage = 1;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rg_acid = GetComponent<Rigidbody>();
        // grabbing the parents forward vector3 from instantiation
        transform.LookAt(Player.transform);
        forward = transform.forward;
        print(forward);
        Invoke("DestroyBullet", 3.1f);
    }

    void Update()
    {
        rg_acid.velocity = forward * speed;  
    }


void OnTriggerEnter(Collider other) {
    // print("do trigger work");
        if (other.gameObject.tag == "Runner")
        {
            counter = 0;
        }

        if(other.gameObject.tag =="Player")
        {
            Player.GetComponent<PlayerHealth>().currentHealth--;
            print(Player.GetComponent<PlayerHealth>().currentHealth);
        }

        counter ++;
        if (counter > 1)
        DestroyBullet();


}

    void DestroyBullet(){
        counter = 0;
        Destroy(gameObject);
    }

    void DeflectBullet()
    {
        transform.position = Vector3.Reflect(transform.position, Vector3.left);
    }
}


