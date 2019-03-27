using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{

    public bool move;
    float moveSpeed = 0.2f;
    public GameObject player;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if(move == true)
        {
            transform.position += player.transform.forward * moveSpeed;
        }
        
    }



    public void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "EarthDragon" && Grab.grab == true){ 
            move = true;
        }

       
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.name == "EarthDragon")
        {
            move = false;
        }
    }



    void FixedUpdate()
    {
        if (move == true && Input.GetKey(KeyCode.W))
        {
           
            rb.AddRelativeForce(player.transform.forward * moveSpeed);
        }

        else if (move == true && Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce( 3* -player.transform.forward * moveSpeed);
        }
        
    }

}



