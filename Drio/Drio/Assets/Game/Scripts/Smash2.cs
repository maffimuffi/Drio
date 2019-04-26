using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash2 : MonoBehaviour
{
    
    bool destroy;

    //GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        //sound = GameObject.FindGameObjectWithTag("PUSound");
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy == true)
        {
            Destroy(this.gameObject);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("pum");
            //sound.GetComponent<smashSound>().on = true;
            destroy = true;
        }



        if (collision.gameObject.CompareTag("EarthShot"))
        {
            Debug.Log("pum");
            //sound.GetComponent<smashSound>().on = true;
            destroy = true;
        }

    }
    

}
