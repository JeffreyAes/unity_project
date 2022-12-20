using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    private GameObject m_camera;
    public GameObject bullet;

    void RemoveObj()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        // don't do this - computing intensive
        // m_camera = GameObject.Find("Main Camera");

        //sets camera to aim punched projectiles
        m_camera = GameObject.FindWithTag("MainCamera");
        Invoke("RemoveObj", 0.06f); //hitbox active for 6 frames

        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("punched a punch a bunch");
        Vector3 pos = gameObject.transform.position;
        Quaternion rot = m_camera.transform.rotation;

        if (other.attachedRigidbody != null)
        {
            if (other.attachedRigidbody.CompareTag("Cube"))
            {
                print("punched a cube");
                Destroy(other.gameObject);
                Instantiate(bullet, pos, rot);

                // other.attachedRigidbody.velocity = m_camera.transform.forward * 100;
            }
        }
    }
}
