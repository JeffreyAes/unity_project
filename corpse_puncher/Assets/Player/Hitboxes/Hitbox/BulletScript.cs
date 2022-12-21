using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb_bullet;
    private GameObject m_camera;
    private Vector3 forward;

    void RemoveObj()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        m_camera = GameObject.FindWithTag("MainCamera");
        rb_bullet = GetComponent<Rigidbody>();
        forward = m_camera.transform.forward;
        print("bullet spawned");
        Invoke("RemoveObj", 3f);
    }

    void FixedUpdate()
    {
        rb_bullet.velocity = forward * 100;
    }

    void OnCollisionEnter(Collision other)
    {
        //this will remove objects of this tag
        if (other.collider.CompareTag("Untagged"))
        {
            //TODO: maybe add particles
            //TODO: add logic to deal damage rather than destroying something
            Destroy(gameObject);
        }
        else
        {
            //bullets don't destroy themselves
            if (other.collider.CompareTag("Bullet"))
            {
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
