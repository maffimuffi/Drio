using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    private GameObject target = null;
    private Vector3 offset;

    int jCount;

    public bool Jumper;
    public bool moving;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        target = null;
    }

   

    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical) * speed * Time.deltaTime;
        Vector3 pushVer = new Vector3(0, 0.0f, -moveVertical) * speed * Time.deltaTime;

        //rb.AddForce(movement * speed);

        rb.MovePosition(transform.position + movement);

        if(Grab.grab == false)
        {
            rb.MovePosition(transform.position + movement);
        }

        if(Grab.grab == true)
        {
            rb.MovePosition(transform.position + pushVer);
        }

        if(Input.GetKey(KeyCode.W))
        {
            moving = true;


        }

        else
        {
            moving = false;
        }


        if (Input.GetButtonDown("Jump") && jCount < 2)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            jCount++;
            

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
            
            


            rb.AddForce(jump * jumpForce * 1.7f, ForceMode.Impulse);

        }

        

    }

    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            Jumper = false;

        }
    }
    */

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


}
