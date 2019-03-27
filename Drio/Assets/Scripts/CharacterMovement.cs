using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    float moveSpeed = 8f;
    float jumpForce = 6f;
    //private float rotateSpeed = 5f;
    public GameObject playerTransform;
    private bool jumpedCounter = false;
    private bool jumped = false;
    private float timer = 0;
    private bool doubleJump;
    private bool characterMovementActive = false;
    private GameObject thisPlayer;
    public CharacterController controller;
    private float jCounter;

    private Vector3 movement;

    private float gravityScale = 1;
   
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        thisPlayer = gameObject;
           setPlayerActive();
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
        if (characterMovementActive)
        {
          
           /* if (Input.GetKey(KeyCode.W))
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
            */

           
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
            float yStore = movement.y;
            movement = (playerTransform.transform.forward * Input.GetAxisRaw("Vertical")) + (playerTransform.transform.right * Input.GetAxisRaw("Horizontal"));
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
            
                if (Input.GetButtonDown("Jump"))
                {
                    movement.y = jumpForce;
                    jCounter++;
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
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Terrain"))
        {
            doubleJump = false;
        } 
    }
}
