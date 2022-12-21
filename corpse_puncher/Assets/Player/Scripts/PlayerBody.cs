using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private int jumps = 1;
    public GameObject kick;
    Rigidbody m_Rigidbody;
    private float horizontalSpeed = 2.0f;
    private float airTime = 0.2f;
    private float jumpCap;
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthbar;
=======
    public CharacterController characterController;
    [SerializeField] private static float defaultSpeed = 12.0f;
    [SerializeField] private static float slideSpeed = defaultSpeed * 2;
    [SerializeField] private static float currentSpeed = defaultSpeed;
    public float gravity = -9.8f;
    private Vector3 velocity;
>>>>>>> main



    public bool isGrounded;
    public bool isSliding;
    private Vector3 standing;
    private Vector3 crouching;



    //GROUNDCHECK
    //receives a transform of a groundCheck object
    public Transform groundCheck;
    //size of the checkSphere
    private float groundDist = 0.5f;
    //checkSphere is looking for this
    public LayerMask groundMask;


    //FOR CALCULATING LINEAR VELOCITY
    private Vector3 _previous;
    private float _velocity;

    void Start()
    {
<<<<<<< HEAD
        m_Rigidbody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
=======
>>>>>>> main
    }

    void EnterSlide()
    {
        // print("player sliding");
        //this will move the groundcheck sphere at crouching, the origin of player
        groundCheck.position = crouching + new Vector3(0, -0.1f, 0);
        characterController.height = 0.9f;
        currentSpeed = slideSpeed;

        isSliding = true;
        //Instantiate(kick) KILLS performance, create a slide hitbox instead of using kick
        // Instantiate(kick, gameObject.transform);
    }

    void ExitSlide()
    {
        if (IsGrounded())
        {
            velocity.y = 1;
        }

        groundCheck.position = gameObject.transform.position + new Vector3(0, -0.7f, 0);
        characterController.height = 2;
        currentSpeed = defaultSpeed;
        isSliding = false;
        //TODO: add a state where a player is "leaving" the slide
    }

    void GroundSlam()
    {
        velocity.y = gravity * 20;
        //more code here
    }

    /* SLIDING
            sliding will:
            decrease player capsule's height
            set a slide direction (based on current movement direction)
            prevent movement
            increase gravity
            set speed of player in that direction
            */
    public bool IsSliding()
    {
        return isSliding;
    }

    public bool IsGrounded()
    {
        //this checks if groundCheck checksphere is touching ground
        return isGrounded;
    }

    /* JUMPING
            description here
    */
    public void SlideJump()
    {
        velocity.y = 10;
    }

    public void Jump()
    {
        velocity.y = 30;

    }

    public void Dodge(Vector3 move)
    {
        velocity = new Vector3(0, 20, 0) + move * 10;
    }



    void Update()
    {
<<<<<<< HEAD
        if (!PauseScreen.isPaused)
        {


            float translation = Input.GetAxis("Vertical") * speed;
            float strafe = Input.GetAxis("Horizontal") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;



            translation *= Time.deltaTime;
            strafe *= Time.deltaTime;
            rotation *= Time.deltaTime;


            if (Input.GetKey("w"))
            {
                m_Rigidbody.transform.Translate(0, 0, translation);
            }
            if (Input.GetKey("s"))
            {
                m_Rigidbody.transform.Translate(0, 0, translation);
            }
            if (Input.GetKey("a"))
            {
                m_Rigidbody.transform.Translate(strafe, 0, 0);
            }
            if (Input.GetKey("d"))
            {
                m_Rigidbody.transform.Translate(strafe, 0, 0);
            }



            if (Input.GetKeyDown("space"))
            {
                jumpCap = Time.time + airTime;
            }
            if (Input.GetKeyUp("space"))
            {
                jumps--;
                print("released jump");
            }


            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                m_Rigidbody.velocity = new Vector3(0, -50, 0);
            }

            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            transform.Rotate(0, h, 0);
            // print(transform.localEulerAngles);



            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(kick, gameObject.transform);
            }



            if (Input.GetKey("space"))
            {
                if (jumps > 0)
                {
                    if (Time.time < jumpCap)
                    {
                        // m_Rigidbody.velocity = new Vector3(0,0,0);
                        m_Rigidbody.AddForce(0, 70f * Time.deltaTime, 0, ForceMode.VelocityChange);
                    }
                }
=======
        //FIXME: consolidate this
        //without the offset, the groundcheck defaults to (0, 0 ,0) of the player, as opposed to (0, -0.7, 0) -where the ground check usually is
        standing = groundCheck.position;
        // print(groundCheck.position);
        crouching = gameObject.transform.position;

        //LINEAR VELOCITY
        // _velocity = ((transform.position - _previous).magnitude) / Time.deltaTime;
        // _previous = transform.position;
        // print(_velocity);

        //CHECK GROUNDEDNESS
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (IsGrounded() && velocity.y < -2f)
        {
            velocity = new Vector3(0, -4f, 0);
        }
        else //if in air, be affected by a downward force
        {
            velocity.y += gravity * 5 * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        //WASD MOVEMENT
        //gets x and z vectors from ranges -1 to 1
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //uses x and z vectors (x,0,0) and (0,0,z)
        //and adds them for a cumulative transform
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F))
        {
            velocity = new Vector3() + move * 30;
        }



        //JUMPING
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            if (IsSliding())
            {
                SlideJump();
            }
            else
            {
                Jump();
>>>>>>> main
            }

            healthbar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                EndGame();
            }

        }

<<<<<<< HEAD

    }

    void FixedUpdate()
    {




        if (m_Rigidbody.velocity.y < 0)
=======
        //GROUND SLAM
        if (Input.GetKeyDown(KeyCode.LeftShift) && !IsGrounded())
>>>>>>> main
        {
            GroundSlam();
        }

        //SLIDE
        else if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
        {
            EnterSlide();
        }

        //LEAVE SLIDE
        if (Input.GetKeyUp(KeyCode.LeftShift) && !IsGrounded())
        {
            Dodge(move);
            ExitSlide();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ExitSlide();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDist);
    }
<<<<<<< HEAD


    void EndGame()
    {
        transform.position = new Vector3(-1262, 44, -3373);

        FindObjectOfType<GameManager>().GameOver();
    }
}
=======
}
>>>>>>> main
