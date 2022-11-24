using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kick : MonoBehaviour
{
    public GameObject m_camera;

    void RemoveObj(){
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // //don't do this
        // m_camera = GameObject.Find("Main Camera");
        //probably better than above code


        //this is doing nothing
        m_camera = GameObject.FindWithTag("MainCamera");
        Invoke("RemoveObj", 0.04f);
    }

    void OnTriggerEnter(Collider other)
    {
        print("kicked");
        
        print(other.attachedRigidbody.CompareTag("Cube"));

        //TODO: add *slight* random rotation on kick
        if(other.attachedRigidbody.CompareTag("Cube")){
            print("kicked a cube");

            // volleyball-like set
            other.attachedRigidbody.velocity = new Vector3(0,10,0);
        }
    }
}
