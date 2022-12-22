using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyAttack : MonoBehaviour
{
    private PlayerBody pBody;
    public GameObject kick;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        pBody = GetComponent<PlayerBody>();
        //grabs animator from the CAMERA
        //may need to add animator to body
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {


        //GROUNDED SLIDE KICK
        if (Input.GetKeyDown(KeyCode.Q) && pBody.IsSliding() && pBody.IsGrounded())
        {
            anim.Play("Kick"); //change this animation
            pBody.SlideJump();
            Instantiate(kick, gameObject.transform);
        }
        //MIDAIR SLIDE KICK
        else if (Input.GetKeyDown(KeyCode.Q) && pBody.IsSliding())
        {
            anim.Play("Kick"); //change this animation
            Instantiate(kick, gameObject.transform);
        }
        //MIDAIR KICK
        else if (Input.GetKeyDown(KeyCode.Q) && !pBody.IsGrounded())
        {
            anim.Play("Kick"); //change this animation
            Instantiate(kick, gameObject.transform);
        }
        //NORMAL KICK
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.Play("Kick");
            Instantiate(kick, gameObject.transform);
        }
    }
}
