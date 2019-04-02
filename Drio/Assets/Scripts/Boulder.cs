using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{


    public GameObject player;
    public Rigidbody rb;

    public bool Push { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       

        
        
    }



    public void OnTriggerEnter(Collider collider)
    {

        if(collider.name == "Push")
        {
            
            Push = true;
        }

        if (collider.name == "EarthDragon2" && Grab.grab == true && Push == true){
            
            transform.parent = collider.transform;


        }

       
    }

    void OnTriggerExit(Collider collider)
    {

        if (collider.name == "Push")
        {
           
            Push = false;
            transform.parent = null;
        }

        if (collider.name == "EarthDragon2")
        {
            transform.parent = null;
        }
    }



}



