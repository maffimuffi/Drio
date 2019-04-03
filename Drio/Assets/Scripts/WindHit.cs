using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHit : MonoBehaviour
{

    // Animation stuff

    private GameObject wind;
    public GameObject windStart;
    public GameObject windEnd;

    private float windSpeed;

    private void Awake()
    {
        windSpeed = 1;
        wind = GameObject.FindGameObjectWithTag("Wind");
        
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
            // Min = 0.43, max = 3.536
            //float dis = Vector3.Distance(other.transform.position, windSpawn.transform.position);
            Debug.Log("Distance: " + dis);
            //float forceMult =
            //other.GetComponent<Rigidbody>().AddForce();

        }
    }
}
