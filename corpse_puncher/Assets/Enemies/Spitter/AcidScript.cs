using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    private Vector3 forward;
    private Rigidbody rg_acid;
    public float speed =10f;
    void Start()
    {
        rg_acid = GetComponent<Rigidbody>();
        // grabbing the parents forward vector3 from instantiation
        forward = transform.parent.forward;
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


