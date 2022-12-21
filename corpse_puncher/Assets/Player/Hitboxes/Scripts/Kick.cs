using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    private HitStop hitStop;
    public Animator anim;
    public GameObject bullet;

    void RemoveObj()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        Invoke("RemoveObj", 0.04f); //hitbox active for 4frames
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            if (other.attachedRigidbody.CompareTag("Corpse"))
            {
                other.attachedRigidbody.velocity = new Vector3(0, 10, 0);
            }
            else if (other.attachedRigidbody.CompareTag("EnemyProjectile"))
            {
                //TODO: destroy enemy projectile
                //make a neutral projectile that will break on contact with ground
                //this projectile can be launched
                other.attachedRigidbody.velocity = new Vector3(0, 10, 0);
            }
        }
    }
}
