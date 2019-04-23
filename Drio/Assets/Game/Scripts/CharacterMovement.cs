using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //animation stuff
    public Animator anim;
    bool isGrounded;
    bool isRunning;

    


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

        yaw += cSpeed * Input.GetAxis("Mouse X");
        //transform.eulerAngles = new Vector3(0, yaw, 0);

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
                transform.eulerAngles = new Vector3(0, 0, 0);

                //Väliaikainen ratkaisu sille ettei kameraa voi kääntää, kun työnnetään!
                cam.transform.eulerAngles = new Vector3(0, 0, 0);


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

           
            
            
            
            
        }
        else
        {
            jCount = 0;
        }


        Quaternion camera = cam.transform.rotation;

        if (Input.GetKey(KeyCode.W) && characterMovementActive == true)
        {
            Quaternion forw = Quaternion.Euler(0, 0 + cam.transform.eulerAngles.y, 0);
            transform.rotation = forw;
        }



        if (Input.GetKey(KeyCode.S) && !Grab.grab && characterMovementActive == true)
        {
            Quaternion back = Quaternion.Euler(0, 180 + cam.transform.eulerAngles.y, 0);
            transform.rotation = back;
        }





        if (Input.GetKey(KeyCode.D) && !Grab.grab && characterMovementActive == true)
        {
            Quaternion right = Quaternion.Euler(0, 90 + cam.transform.eulerAngles.y, 0);
            transform.rotation = right;
        }




        if (Input.GetKey(KeyCode.A) && !Grab.grab && characterMovementActive == true)
        {
            Quaternion left = Quaternion.Euler(0, 270 + cam.transform.eulerAngles.y, 0);
            transform.rotation = left;
        }

        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.D)) && !Grab.grab && characterMovementActive == true)
        {
            Quaternion ne = Quaternion.Euler(0, 45 + cam.transform.eulerAngles.y, 0);
            transform.rotation = ne;
        }



        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.A)) && !Grab.grab && characterMovementActive == true)
        {
            Quaternion nw = Quaternion.Euler(0, 315 + cam.transform.eulerAngles.y, 0);
            transform.rotation = nw;
        }

        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A)) && !Grab.grab && characterMovementActive == true)
        {
            Quaternion sw = Quaternion.Euler(0, 225 + cam.transform.eulerAngles.y, 0);
            transform.rotation = sw;
        }

        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.D)) && !Grab.grab && characterMovementActive == true)
        {
            Quaternion se = Quaternion.Euler(0, 135 + cam.transform.eulerAngles.y, 0);
            transform.rotation = se;
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


        }


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
