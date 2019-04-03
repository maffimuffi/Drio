using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHit : MonoBehaviour
{
    // Animation stuff

    private GameObject windStart;

    private float windSpeed;
    private float windMult;
    private float dis;

    private bool windPush;

    private void Awake()
    {
        windSpeed = 1;
        windMult = 0;
        windStart = GameObject.Find("WindStart");
        windPush = false;

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
        if (other.tag == "Test")
        {
            dis = Vector3.Distance(windStart.transform.position, other.transform.position);

            // Set the ranges to increase how effective the wind is
            if(dis >= 5.8f)
            {
                dis = 5.7f;
                windMult = 1.0f;
            }
            else if(dis < 5.8f && dis >= 5.0f)
            {
                windMult = 1.0f;
            }
            else if(dis < 5.0f && dis >= 4.0f)
            {
                windMult = 1.5f;
            }
            else if(dis < 4.0 && dis >= 3.0f)
            {
                windMult = 2.0f;
            }
            else if(dis < 3 && dis >= 2)
            {
                windMult = 2.5f;
            }
            else if(dis < 2 && dis >= 1)
            {
                windMult = 3.0f;
            }
            else if(dis < 1)
            {
                windMult = 3.5f;
            }
            
            // Script to push the object with wind

        }
    }
}
