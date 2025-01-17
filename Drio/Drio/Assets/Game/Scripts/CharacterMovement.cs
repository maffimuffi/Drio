﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //animation stuff
    public Animator anim;
    public GameObject smoothCamera;
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public GameObject spawnpoint3;
    public GameObject spawnpoint4;

    

    bool isGrounded;
    bool isRunning;
    bool isWalking;
    float smoothing = -10;


    public float AccelerationDecreaser = 2f;
    public float walkSpeedMultiply = 1;
    float runSpeedMultiply;
    public float smoothRotation2 = 0.2f;
    public float smoothRotation = 4f;
    public static float moveSpeed = 12f;
    public float moveSpeedMultiply = 1.3f;
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
    private float yaw = 0f;
    private float cSpeed = 2f;

    public GameObject cam;

    //private float gravityScale = 1;


    // Start is called before the first frame update
    void Start()
    {
        //animation stuff
        // anim.SetBool("isJumping", false);
        isGrounded = true;
        isRunning = false;
        isWalking = false;
        runSpeedMultiply = moveSpeedMultiply;


        gravityScale = Physics.gravity.y;
        thisPlayer = gameObject;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        //setPlayerActive();

        if (thisPlayer.name == "WindDragon")
        {
            playerTransform = GameObject.Find("WindTransformPoint");
        }
        else if (thisPlayer.name == "FireDragon")
        {
            playerTransform = GameObject.Find("FireTransformPoint");
        }
        else if (thisPlayer.name == "EarthDragon")
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
            smoothing = -10;
            characterMovementActive = true;
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
        else if (thisPlayer.name == "WindDragon" && PlayerChanger.CharacterSelect == 1)
        {
            smoothing = -10;
            characterMovementActive = true;
        }
        else if (thisPlayer.name == "FireDragon" && PlayerChanger.CharacterSelect == 3)
        {
            characterMovementActive = true;
            smoothing = -10;
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
        else
        {
            characterMovementActive = false;
        }
    }

    private void LateUpdate()
    {

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

        if (CamInstruction.active == true)
        {
            Debug.Log("täällä");
        }
        else
        {

            yaw += cSpeed * Input.GetAxis("Mouse X");
            //transform.eulerAngles = new Vector3(0, yaw, 0);

            //Draw hyppy mahd


            if (isGrounded)
            {
                anim.SetBool("isGliding", false);

            }

            if (characterMovementActive)
            {

                Debug.DrawRay(transform.position, -transform.up, Color.blue, 0.5f);
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


                Vector3 horMovement = playerTransform.transform.right * moveHorizontal * moveSpeed * Time.deltaTime * moveSpeedMultiply;
                Vector3 verMovement = playerTransform.transform.forward * moveVertical * moveSpeed * Time.deltaTime * moveSpeedMultiply;

                //anim.SetFloat("Speed", move);

                //Vector3 pMovement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;
                Vector3 pMovement = horMovement + verMovement;
                Vector3 pushVer = new Vector3(0, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;

                if (transform.position.y < -1)
                {
                    if (OpenDoorAni.trigger2 == 0)
                    {
                        transform.position = spawnpoint1.transform.position;
                    }
                    if (OpenDoorAni.trigger2 == 1)
                    {
                        transform.position = spawnpoint2.transform.position;
                    }
                    if (OpenDoorAni.trigger2 == 2 || OpenDoorAni.trigger2 == 3)
                    {
                        transform.position = spawnpoint3.transform.position;
                    }
                    if (OpenDoorAni.trigger2 == 4)
                    {
                        transform.position = spawnpoint4.transform.position;
                    }

                    Debug.Log("Hups!");
                }


                if (!Grab.grab || PlayerChanger.CharacterSelect != 2)
                {

                    rb.MovePosition(transform.position + pMovement);


                }
                else if (Grab.grab && PlayerChanger.CharacterSelect == 2)
                {

                    //rb.MovePosition(transform.position + pushVer);
                    rb.MovePosition(transform.position + pMovement);
                    //Quaternion forw = Quaternion.Euler(0, 0 + cam.transform.eulerAngles.y, 0);
                    //transform.eulerAngles = new Vector3(0, 0, 0);

                    //Väliaikainen ratkaisu sille ettei kameraa voi kääntää, kun työnnetään!
                    //cam.transform.eulerAngles = new Vector3(0, 0, 0);


                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (isGrounded == false)
                    {
                        anim.SetBool("isJumping", false);
                    }
                }

                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) ||
                    Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
                {
                    if (isGrounded == true)
                    {
                        anim.SetBool("isRunning", true);
                        isRunning = true;
                        if (moveSpeedMultiply < runSpeedMultiply)
                        {
                            moveSpeedMultiply = moveSpeedMultiply + runSpeedMultiply * Time.deltaTime / AccelerationDecreaser;

                        }

                        /* smoothing -= Time.deltaTime;
                        if (smoothing > -13)
                        {
                            smoothCamera.transform.localPosition = new Vector3(0, 6.26f, smoothing);
                        }
                        else
                        {
                            smoothCamera.transform.localPosition = new Vector3(0, 6.26f, -13);
                        }
                        */

                        rotating = true;
                    }
                    else
                    {
                        isGrounded = false;
                    }


                }
                else
                {
                    rotating = false;
                    anim.SetBool("isRunning", false);
                    isRunning = false;
                }

                if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift) ||
                   Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
                {
                    //smoothing = -10;
                    if (isGrounded == true)
                    {
                        anim.SetBool("isWalking", true);
                        isWalking = true;

                        moveSpeedMultiply = walkSpeedMultiply;
                        rotating = true;
                    }
                    else
                    {
                        isGrounded = false;
                        isWalking = false;
                        anim.SetBool("isWalking", false);

                    }


                }
                else
                {
                    rotating = false;
                    anim.SetBool("isWalking", false);
                    isWalking = false;

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


                if (Input.GetButtonDown("Jump"))
                {
                    if (isRunning)
                    {
                        anim.SetBool("isRunningJumping", true);

                        isGrounded = false;
                    }

                    if (isRunning == false)
                    {
                        anim.SetBool("isJumping", true);
                        anim.SetBool("isRunningJumping", false);
                        isGrounded = false;
                    }
                    if (isWalking)
                    {
                        //anim.SetBool("isJumping", true);

                        isGrounded = false;
                    }
                    if (jCount < 1)
                    {



                        rb.velocity = new Vector3(0, 0.01f, 0);
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
                        rb.velocity = new Vector3(0, 0.01f, 0);
                        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                        jCount++;
                    }
                }



                //Only wind dragon can fly 
                if (Input.GetKey(KeyCode.Space) && isGrounded == false)
                {

                    if (PlayerChanger.CharacterSelect == 1)
                    {


                        var localVel = transform.InverseTransformDirection(rb.velocity);

                        if (localVel.y < 0 && jCount > 0)
                        {
                            anim.SetBool("isGliding", true);
                            Physics.gravity = new Vector3(0, -4, 0);
                            rb.AddForce(new Vector3(transform.forward.x * Time.deltaTime, 0, transform.forward.z * Time.deltaTime));

                        }
                        else
                        {

                            //anim.SetBool("isGliding", false);
                            Physics.gravity = new Vector3(0, -9.81f, 0);
                        }

                    }
                }








            }
            else
            {
                jCount = 0;
            }




            Quaternion camera = cam.transform.rotation;

            if (Input.GetKey(KeyCode.W) && characterMovementActive == true)
            {
                if (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
                {
                    Quaternion forw = Quaternion.Euler(0, 0 + cam.transform.eulerAngles.y, 0);
                    //Severin lisäys. Smooth rotation
                    transform.rotation = Quaternion.Slerp(transform.rotation, forw, smoothRotation * Time.deltaTime);
                }
                

                // transform.rotation = forw;
                if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.D)) && characterMovementActive == true)
                {
                    Quaternion ne = Quaternion.Euler(0, 45 + cam.transform.eulerAngles.y, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, ne, smoothRotation2 * Time.deltaTime/500);
                    //transform.rotation = ne;
                }



                if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.A)) && characterMovementActive == true)
                {
                    Quaternion nw = Quaternion.Euler(0, 315 + cam.transform.eulerAngles.y, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, nw, smoothRotation2 * Time.deltaTime/500);
                    //transform.rotation = nw;
                }
            }



            if (Input.GetKey(KeyCode.S) && characterMovementActive == true)
            {
                if (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
                {
                    Quaternion back = Quaternion.Euler(0, 180 + cam.transform.eulerAngles.y, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, back, smoothRotation * Time.deltaTime);
                    //transform.rotation = back;
                }

                if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A)) && characterMovementActive == true)
                {
                    Quaternion sw = Quaternion.Euler(0, 225 + cam.transform.eulerAngles.y, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, sw, smoothRotation2 * Time.deltaTime/500);
                    //transform.rotation = sw;
                }

                if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.D)) && characterMovementActive == true)
                {
                    Quaternion se = Quaternion.Euler(0, 135 + cam.transform.eulerAngles.y, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, se, smoothRotation2 * Time.deltaTime/500);
                    //transform.rotation = se;
                }
            }





            if (Input.GetKey(KeyCode.D) && characterMovementActive == true)
            {
                Quaternion right = Quaternion.Euler(0, 90 + cam.transform.eulerAngles.y, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, right, smoothRotation * Time.deltaTime);
                //transform.rotation = right;

            }




            if (Input.GetKey(KeyCode.A) && characterMovementActive == true)
            {
                Quaternion left = Quaternion.Euler(0, 270 + cam.transform.eulerAngles.y, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, left, smoothRotation * Time.deltaTime);
                //transform.rotation = left;
            }

            

            
            // flying rotation
            if (isGrounded == false && Input.GetKey(KeyCode.LeftShift))
            {
                Quaternion flyRot_R = Quaternion.Euler(0, 0, 10f + cam.transform.eulerAngles.z);
                float rotaatioY = transform.localRotation.y;

                float testiRotaatio = rotaatioY / 10;
                Vector3 flyRotation = new Vector3(transform.localRotation.x, transform.localRotation.y, testiRotaatio);
                //Debug.Log("y rotaatio" + rotaatioY);
                //transform.localEulerAngles = rotaatioY;

            }

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
            if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Boulder")
            {

                isGrounded = true;
                anim.SetBool("isJumping", false);
                anim.SetBool("isRunningJumping", false);



            }


            if (collision.gameObject.CompareTag("PU"))
            {
                collision.gameObject.SetActive(false);

            }

            if (collision.gameObject.CompareTag("Bounce"))
            {

                Debug.Log("Jippii");


                rb.AddForce(jump * jumpForce * 1.2f, ForceMode.Impulse);

            }

            /* if (PlayerChanger.CharacterSelect == 1 && NavMeshToLevel2.counter == 1)
            {
                fireDragon.transform.position = level2spawn.transform.position;
                earthDragon.transform.position = level2spawn.transform.position;
            }
            if (PlayerChanger.CharacterSelect == 2 && NavMeshToLevel2.counter == 1)
            {
                fireDragon.transform.position = level2spawn.transform.position;
                windDragon.transform.position = level2spawn.transform.position;
            }
            if (PlayerChanger.CharacterSelect == 3 && NavMeshToLevel2.counter == 1)
            {
                windDragon.transform.position = level2spawn.transform.position;
                earthDragon.transform.position = level2spawn.transform.position;
            }
            */
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