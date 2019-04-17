﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //animation stuff
    public Animator anim;
    bool isGrounded;
    bool isRunning;

    
    private UITextPopup uiText;


    public float moveSpeed = 6f;
    float jumpForce = 250f;
    //private float rotateSpeed = 5f;
    
    [HideInInspector]
    public GameObject playerTransform;
    private GameObject thisPlayer;

//    private bool jumpedCounter = false;
//    private bool jumped = false;
    private bool allowJump;
    private bool doubleJump;
    public bool rotating;
    private bool characterMovementActive = false;

//    private float timer = 0;
    private float gravityScale;

    public Vector3 jump;

    private Rigidbody rb;

    private int jCount;

    [HideInInspector]
    
    private float jCounter;

    private Vector3 movement;
    private Vector3 spin;

    

    int jumpHashFD = Animator.StringToHash("FD_Jump");
    int runStateHash = Animator.StringToHash("Base Layer.Run");


    //private float gravityScale = 1;


    // Start is called before the first frame update
    void Start()
    {
        //animation stuff
        // anim.SetBool("isJumping", false);
        isGrounded = true;
        isRunning = false;

        uiText = GameObject.Find("TextPopup").GetComponent<UITextPopup>();

        gravityScale = Physics.gravity.y;
        thisPlayer = gameObject;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
           //setPlayerActive();

        if (thisPlayer.name == "WindDragon")
        {
            playerTransform = GameObject.Find("WindTransformPoint");
        } else if (thisPlayer.name == "FireDragon")
        {
            playerTransform = GameObject.Find("FireTransformPoint");
        } else if (thisPlayer.name == "EarthDragon")
        {
            playerTransform = GameObject.Find("EarthTransformPoint");
        }


        spin = new Vector3(0, 100, 0);

        anim = GetComponent<Animator>();

    }

    public void setPlayerActive()
    {
        
        if (thisPlayer.name == "EarthDragon" && PlayerChanger.CharacterSelect == 2)
        {
            characterMovementActive = true;
        } else if (thisPlayer.name == "WindDragon" && PlayerChanger.CharacterSelect == 1)
        {
            characterMovementActive = true;
        } else if (thisPlayer.name == "FireDragon" && PlayerChanger.CharacterSelect == 3)
        {
            characterMovementActive = true;
        }
        else
        {
            characterMovementActive = false;
        }
        uiText.ExitSite();
    }


    // Update is called once per frame
    void Update()
    {
        /* if (jumpedCounter)
         {
             timer += Time.deltaTime;
             if (timer >= 0.5)
             {
                 timer = 0;
                 jumped = true;
                 jumpedCounter = false;
             }
         }
         */

        //Draw hyppy mahd


        if (isGrounded) {
            anim.SetBool("isGliding", false);
        }

        if (characterMovementActive)
        {
            
            Debug.DrawRay(transform.position,-transform.up,Color.blue,0.5f);
            RaycastHit hit;

            //tämä pieni paska sen takia koska jcountin chekkaaminen paljon kevyempää kuin kaikkien kolmen.
            if (jCount != 0)
            {
                if (Physics.Raycast(transform.position, -transform.up, out hit, 0.6f) && rb.velocity.y <= 0)
                {

                    if (hit.transform.tag == "Object" || hit.transform.tag == "Terrain" ||
                        hit.transform.tag == "Boulder" || hit.transform.tag == "Push")
                    {
                        jCount = 0;
                        Physics.gravity = new Vector3(0, -9.81f, 0);
                    }
                }
            }

            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            
            
            Vector3 horMovement = playerTransform.transform.right * moveHorizontal * moveSpeed * Time.deltaTime;
            Vector3 verMovement = playerTransform.transform.forward * moveVertical * moveSpeed * Time.deltaTime;

            //anim.SetFloat("Speed", move);

            //Vector3 pMovement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;
            Vector3 pMovement = horMovement + verMovement;
            Vector3 pushVer = new Vector3(0, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;

            if(transform.position.y < -1)
            {
                transform.position = new Vector3(transform.position.x, 0.415f, transform.position.y);
                Debug.Log("Hups!");
            }

            if (!Grab.grab || PlayerChanger.CharacterSelect != 2)
            {

                rb.MovePosition(transform.position + pMovement);


            } else if (Grab.grab && PlayerChanger.CharacterSelect == 2)
            {
                
                rb.MovePosition(transform.position + pushVer);
                
                
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
            {
                //kokeilu
                anim.SetBool("isRunning", true);
                isRunning = true; 

                rotating = true;
                
            }
            else
            {
                rotating = false;
                anim.SetBool("isRunning", false);
            }

            if (rotating)
            {
                if (Grab.grab)
                {
                    Quaternion deltaRotation = Quaternion.Euler(spin * Time.deltaTime);
                    rb.MoveRotation(deltaRotation);
                    //en saa rotaatiota toimimaan grabatessa
                }
                else
                {
                    rb.MoveRotation(playerTransform.transform.rotation); 
                    
                }
            }
            
            /*
            if (!Grab.grab)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += playerTransform.transform.forward * moveSpeed;
                    transform.rotation = playerTransform.transform.rotation;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    transform.position += -playerTransform.transform.forward * moveSpeed;
                    transform.rotation = playerTransform.transform.rotation;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += -playerTransform.transform.right * moveSpeed;
                    transform.rotation = playerTransform.transform.rotation;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += playerTransform.transform.right * moveSpeed;
                    transform.rotation = playerTransform.transform.rotation;
                }
            } else if (Grab.grab)
            {
                transform.position += playerTransform.transform.forward * moveSpeed;
            }
*/
            if (Input.GetButtonDown("Jump"))
            {
                if (isRunning) {
                    anim.SetBool("isRunningJumping", true);
                    isGrounded = false; 
                }

                if (isRunning == false)
                {
                    anim.SetBool("isJumping", true);
                    anim.SetBool("isRunningJumping", false);
                    isGrounded = false;
                }
                if (jCount < 1)
                 {



                     rb.velocity = new Vector3(0,0.01f,0);
                    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                    jCount++;
                    anim.SetTrigger(jumpHashFD);
                    //animaatio
                    /*
                    if (isGrounded == false) {
                        anim.SetBool("isJumping", true);
                        Debug.Log("meneeks tä ikinä tänne?");
                    }
                    */
                }
                else if (PlayerChanger.CharacterSelect == 1 && jCount < 2)
                 {
                     rb.velocity = new Vector3(0,0.01f,0);
                    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                    jCount++;    
                }
            }

            /*if (Input.GetButton("Jump") && PlayerChanger.CharacterSelect == 1 && jCount < 2 && jCount > 1)
            {
                Physics.gravity = new Vector3(0, -5, 0);
            }
            */

            //Only wind dragon can fly 
           if (Input.GetKey(KeyCode.LeftShift))
            {
                if (PlayerChanger.CharacterSelect == 1)
                {
                    

                    var localVel = transform.InverseTransformDirection(rb.velocity);
                    
                    if (localVel.y < 0 && jCount > 0)
                    {
                        anim.SetBool("isGliding", true);
                        Physics.gravity = new Vector3(0, -5, 0);
                    }
                    else
                    {

                        //anim.SetBool("isGliding", false);
                        Physics.gravity = new Vector3(0, -9.81f, 0);
                    }

                }
            }

           
            
            
            
            
/*
            //Debuggaus speed yms
            //Debug.Log("Rigidbody speed: " + gameObject.GetComponent<Rigidbody>().velocity.magnitude + " jumped: " + jumped);
            if (jumped && gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 0 &&
                gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 0.5)
            {
                //impulse huono. näyttää epärealistiselta.
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * (jumpSpeed / 2), ForceMode.Impulse);
                jumped = false;
            }
  */
            
            
            //Script by Don Antti
           /* float yStore = movement.y;
            movement = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            movement = movement.normalized * moveSpeed;
            movement.y = yStore;
            if (movement.x > 0 || movement.z > 0 || movement.x < 0 || movement.z < 0)
            {
                transform.rotation = playerTransform.transform.rotation;
            }
            if (controller.isGrounded)
            {
                movement.y = 0f;
                jCounter = 0;
                gravityScale = 1;
            
                if (Input.GetButtonDown("Jump"))
                {
                    movement.y = jumpForce;
                    jCounter++;
                }
            }

            else if
            (!controller.isGrounded)
            {
                // Gliding with left shift
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    gravityScale = 0.25f;
                    movement.y = movement.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
                }
            }

            else if (!controller.isGrounded && jCounter < 2 && PlayerChanger.CharacterSelect == 1)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    movement.y = jumpForce;
                    jCounter++;
                }
            }

            movement.y = movement.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            
            controller.Move(movement * Time.deltaTime);
*/

/*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //not working
                Debug.DrawRay(transform.position, Vector3.down, Color.green, 0.5f);
                RaycastHit ground;

               
                    if (PlayerChanger.CharacterSelect == 1)
                    {
                        if (doubleJump)
                        {
                            doubleJump = false;
                        }
                        else if (!doubleJump)
                        {
                            doubleJump = true;

                        }
                    

                }
            }
            */
        }
        else
        {
            jCount = 0;
        }
        
    }

    void Glide()
    {
        gravityScale = 0.25f;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * gravityScale, rb.velocity.z);
        Debug.Log("gliding");
    }
    public bool IsPlayerActive()
    {
        return characterMovementActive;
    }
    
    void OnCollisionEnter(Collision collision)
    {



        //animation stuff 
        if (collision.gameObject.tag == "Terrain") {

            isGrounded = true;
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunningJumping", false);

            Debug.Log("Isgrounde on true"); 
        }






        /*
        if (collision.gameObject.CompareTag("Object"))
        {
            
            jCount = 0;

        }

        if (collision.gameObject.CompareTag("Terrain"))
        {

            jCount = 0;

        }

        if (collision.gameObject.CompareTag("Boulder"))
        {

            jCount = 0;
            

        }

        if (collision.gameObject.CompareTag("Push"))
        {

            jCount = 0;

        }
*/
        if (collision.gameObject.CompareTag("PU"))
        {
            collision.gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("Bounce"))
        {
            
            Debug.Log("Jippii");


            rb.AddForce(jump * jumpForce * 3f, ForceMode.Impulse);

        }

        

    }

    public void ResetJump()
    {
        jCount = 0;
    }

   

    /*
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "mPlatform" && moving == false)
        {

            

            transform.parent = other.transform;
            

        }

        
    }



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "mPlatform")
        {
           
            transform.parent = null;

        }
    }
*/
}
