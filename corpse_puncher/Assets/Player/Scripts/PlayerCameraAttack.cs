using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraAttack : MonoBehaviour
{
    private PlayerBody pBody;
    public Animator anim;
    public GameObject punch;


    void Start()
    {
        pBody = GetComponentInParent<PlayerBody>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {

        //GROUNDED SLIDE PUNCH
        if (Input.GetKeyDown(KeyCode.E) && pBody.IsSliding() && pBody.IsGrounded())
        {
            anim.Play("Punch"); //change this animation
            Instantiate(punch, gameObject.transform);
        }
        //MIDAIR SLIDE PUNCH
        else if (Input.GetKeyDown(KeyCode.E) && pBody.IsSliding())
        {
            anim.Play("Punch"); //change this animation
            Instantiate(punch, gameObject.transform);
        }
        //MIDAIR PUNCH
        else if (Input.GetKeyDown(KeyCode.E) && !pBody.IsGrounded())
        {
            anim.Play("Punch"); //change this animation
            Instantiate(punch, gameObject.transform);
        }
        //NORMAL PUNCH
        else if (Input.GetKeyDown(KeyCode.E))
        {
            anim.Play("Punch");
            Instantiate(punch, gameObject.transform);
        }
    }
}
