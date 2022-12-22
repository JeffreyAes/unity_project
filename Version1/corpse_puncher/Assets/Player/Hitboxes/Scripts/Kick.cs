using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    private HitStop hitStop;
    private Vector3 pos;
    public Animator anim;
    public GameObject bullet;
    public GameObject Corpse;


    void RemoveObj()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        Invoke("RemoveObj", 0.06f); //hitbox active for 6frames
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 pos = gameObject.transform.position;

        if (other.attachedRigidbody != null)
        {
            if (other.attachedRigidbody.CompareTag("Corpse"))
            {
                other.attachedRigidbody.velocity = new Vector3(0, 6, 0);
            }
            else if (other.attachedRigidbody.CompareTag("EnemyProjectile"))
            {
                //TODO: destroy enemy projectile
                //make a neutral projectile that will break on contact with ground
                //this projectile can be launched
                Destroy(other.gameObject);
                Instantiate(Corpse, pos, Quaternion.identity);
            }
            else if (other.attachedRigidbody.CompareTag("Enemy"))
            {
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(Corpse, pos, Quaternion.identity);
                }
            }
        }
    }
}
