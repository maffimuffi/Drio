using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{


    public GameObject player;
    public Rigidbody rb;
    public bool pusher;
    public int doorNum = 1;
    public bool open;
    public AudioSource sound;

    public float moveX;
    public float moveZ;
    


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
            rb.MovePosition(transform.position + new Vector3(moveX,0,moveZ) * Time.deltaTime);
        }

        if(open == true && doorNum < 2)
        {
            Debug.Log("test");
            doorNum = 2;
            OpenDoor.trigger += 1;
        }
        
    }

    


    public void OnTriggerEnter(Collider collider)
    {

        if(collider.name == "Push")
        {
            
            Push = true;
        }

        if ((collider.name == "EarthDragon" && Grab.grab == true && Push == true)){

            //transform.parent = collider.transform;
            pusher = true;
            sound.Play();


        }

        if (collider.name == "PushBlock")
        {

            //OpenDoor.trigger = doorNum;
            open = true;


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
            sound.Stop();
        }

       
    }



}



