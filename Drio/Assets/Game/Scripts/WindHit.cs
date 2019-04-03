using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHit : MonoBehaviour
{

    // Animation stuff

    //public WindBreath wind;

    private float windSpeed;

    private void Awake()
    {
        windSpeed = 1;
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        // Trigger to shut down fire
        if (other.tag == "onFire")
        {
            // Animation?
            Destroy(other.gameObject);
        }

        // Trigger to move object with wind
        if(other.tag == "Test")
        {
            float dis = Vector3.Distance(other.transform.position, PlayerChanger.ActivePlayer.transform.position);
            //float forceMult =
            //other.GetComponent<Rigidbody>().AddForce();

        }
    }
}
