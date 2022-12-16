using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public GameObject m_camera;

    void RemoveObj()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        // don't do this
        // m_camera = GameObject.Find("Main Camera");


        //sets camera to aim punched projectiles
        m_camera = GameObject.FindWithTag("MainCamera");
        Invoke("RemoveObj", 0.04f); //hitbox active for 4frames
    }

    void OnTriggerEnter(Collider other)
    {
        print("kicked");

        if (other.attachedRigidbody != null)
        {
            //consolidate into a function
            if (other.attachedRigidbody.CompareTag("Corpse"))
            {
                print("kicked corpse");
                other.attachedRigidbody.velocity = new Vector3(0, 10, 0);
            } else if (other.attachedRigidbody.CompareTag("EnemyProjectile")){
                print("kicked projectile");
                other.attachedRigidbody.velocity = new Vector3(0, 10, 0);
            }
        }
        //TODO: add *slight* random rotation on kick
    }
}
