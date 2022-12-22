using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Punch : MonoBehaviour
{
    private GameObject m_camera;
    private HitStop hitStop;
    public GameObject bullet;
    public Animator anim;
    public GameObject Corpse;


    void RemoveObj()
    {
        //TODO: hit particles can occur
        Destroy(gameObject);
    }

    void Start()
    {
        m_camera = GameObject.FindWithTag("MainCamera");
        anim = m_camera.GetComponentInChildren<Animator>();
        hitStop = GetComponent<HitStop>();
        Invoke("RemoveObj", 0.06f); //hitbox active for 6 frames
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 pos = gameObject.transform.position;
        Quaternion rot = m_camera.transform.rotation;

        if (other.attachedRigidbody != null)
        {
            anim.StopPlayback();
            if (other.attachedRigidbody.CompareTag("Corpse"))
            {
                //FIXME: consolidate into a function
                anim.Play("PunchConnected");
                hitStop.Freeze();
                //TODO: add screenshake
                Destroy(other.gameObject);
                Instantiate(bullet, pos, rot);
            }
            else if (other.attachedRigidbody.CompareTag("EnemyProjectile"))
            {
                anim.Play("PunchConnected");
                hitStop.Freeze();
                Destroy(other.gameObject);
                Instantiate(bullet, pos, rot);
            }
            else if (other.attachedRigidbody.CompareTag("Enemy"))
            {
                anim.Play("PunchConnected");
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(Corpse, pos, Quaternion.identity);
                }
            }
        }
    }
}
