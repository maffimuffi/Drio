using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{


    public GameObject player;
    public Rigidbody rb;
    public bool pusher;


    public bool Push { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(pusher == true && Push == true)
        {
            rb.MovePosition(transform.position + new Vector3(0,0,-2) * Time.deltaTime);
        }

        
        
    }



    public void OnTriggerEnter(Collider collider)
    {

        if(collider.name == "Push")
        {
            
            Push = true;
        }

        if ((Input.GetKey(KeyCode.W) && collider.name == "EarthDragon" && Grab.grab == true && Push == true)){

            //transform.parent = collider.transform;
            pusher = true;
            

        }

       
    }

    void OnTriggerExit(Collider collider)
    {

        if (collider.name == "Push")
        {
           
            Push = false;
            //transform.parent = null;
        }

        if (collider.name == "EarthDragon")
        {
            //transform.parent = null;
            pusher = false;
        }
    }



}



