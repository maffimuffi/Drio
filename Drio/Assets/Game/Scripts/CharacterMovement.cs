using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    public float moveSpeed = 6f;
    float jumpForce = 1.8f;
    //private float rotateSpeed = 5f;
    
    [HideInInspector]
    public GameObject playerTransform;
    private bool jumpedCounter = false;
    private bool jumped = false;
    private float timer = 0;
    public Vector3 jump;
    private Rigidbody rb;
    
    private bool doubleJump;
    int jCount;
    public bool rotating;
    
    
    private bool characterMovementActive = false;
    private GameObject thisPlayer;

    [HideInInspector]
    
    private float jCounter;

    private Vector3 movement;
    private Vector3 spin;


    //private float gravityScale = 1;


    // Start is called before the first frame update
    void Start()
    {
       
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
    void FixedUpdate()
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
        if (characterMovementActive)
        {
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            
            
            Vector3 horMovement = playerTransform.transform.right * moveHorizontal * moveSpeed * Time.deltaTime;
            Vector3 verMovement = playerTransform.transform.forward * moveVertical * moveSpeed * Time.deltaTime;
            
            //Vector3 pMovement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;
            Vector3 pMovement = horMovement + verMovement;
            Vector3 pushVer = new Vector3(0, 0.0f, -moveVertical) * moveSpeed * Time.deltaTime;

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
                rotating = true;
            }
            else
            {
                rotating = false;
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
            if (Input.GetButtonDown("Jump") && jCount < 2)
            {
                

                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                jCount++;

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
            
            
            //Script by Antti
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
        
    }

    void OnCollisionEnter(Collision collision)
    {
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
