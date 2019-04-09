using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public ParticleSystem system;
    bool ani;
    public AudioSource Tsound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ani == true)
        {
            system.Play();
        }
        
    }


    
     void OnTriggerEnter(Collider collision)
     {
            if (collision.gameObject.CompareTag("FireShot") && ani == false)
            {
                Tsound.Play();
                OpenDoor.trigger += 1;
                //sound.GetComponent<smashSound>().on = true;
                Debug.Log(OpenDoor.trigger);
                ani = true;
            }
     }

    

}
