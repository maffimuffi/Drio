using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    float moveSpeed = 0.2f;
    float jumpSpeed = 150f;
    private float rotateSpeed = 5f;
    public GameObject playerTransform;
    private bool jumpedCounter = false;
    private bool jumped = false;
    private float timer = 0;
    private bool doubleJump;
    
    
   
    
    // Start is called before the first frame update
    void Start()
    {       
        
    }

    // Update is called once per frame
    void Update()
    {
        
   
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += playerTransform.transform.forward * moveSpeed;
            transform.rotation = playerTransform.transform.rotation;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -playerTransform.transform.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -playerTransform.transform.right * moveSpeed;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += playerTransform.transform.right * moveSpeed;
        }

        if (jumpedCounter)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5)
            {
                timer = 0;
                jumped = true;
                jumpedCounter = false;
            }
        }
        
        //Debuggaus speed yms
        //Debug.Log("Rigidbody speed: " + gameObject.GetComponent<Rigidbody>().velocity.magnitude + " jumped: " + jumped);
        if (jumped && gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 0 && gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 0.5)
        { //impulse huono. näyttää epärealistiselta.
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * (jumpSpeed / 2), ForceMode.Impulse);
            jumped = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //not working
            Debug.DrawRay(transform.position,Vector3.down,Color.green,0.5f);
            RaycastHit ground;
            
            if (Physics.Raycast(transform.position, Vector3.down, out ground, 0.5f)  || doubleJump)
            {
            
                
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                
                jumpedCounter = true;
                if (PlayerChanger.CharacterSelect == 1)
                {
                    if (doubleJump) 
                    {doubleJump = false;} else
                    if (!doubleJump)
                    {
                        doubleJump = true;

                    }
                }
                
            }
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
