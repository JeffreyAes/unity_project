using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    private Vector3 forward;
    private Rigidbody rg_acid;
    private GameObject Player;
    public float speed =10f;
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
    print("do trigger work");
}

    void DestroyBullet(){
        Destroy(gameObject);
    }
}

