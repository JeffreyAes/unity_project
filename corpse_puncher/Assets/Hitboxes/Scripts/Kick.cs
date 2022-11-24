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
            if (other.attachedRigidbody.CompareTag("Cube"))
            {
                print("kicked a cube");
                other.attachedRigidbody.velocity = new Vector3(0, 10, 0);
            }
        }
        //TODO: add *slight* random rotation on kick
    }
}
