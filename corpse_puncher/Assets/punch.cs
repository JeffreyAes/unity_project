using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    private GameObject m_camera;
    void RemoveObj()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        // //don't do this - computing intensive
        // m_camera = GameObject.Find("Main Camera");
        //probably better than above code


        //this is doing nothing
        m_camera = GetComponent<GameObject>();
        m_camera = GameObject.FindWithTag("MainCamera");

        //activates sphere for 6frames
        Invoke("RemoveObj", 0.06f);
    }
    private void OnTriggerEnter(Collider other)
    {
        //TODO: delete cube
        //launch sphere as a projectile
        print("punched");

        //
        print(other.GetType());

        if (other.attachedRigidbody != null)
        {
            if (other.attachedRigidbody.CompareTag("Cube"))
            {
                print("punched a cube");

                other.attachedRigidbody.velocity = m_camera.transform.forward * 100;

            }
        }

        // other.attachedRigidbody.velocity = (m_camera.transform.localEulerAngles);
    }
}
