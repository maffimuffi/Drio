using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHit : MonoBehaviour
{
    // Animation stuff

    private GameObject windStart;
    private GameObject player;

    private float windSpeed;
    private float windMult;
    private float dis;

    private bool windPush;

    private void Awake()
    {
        windStart = GameObject.Find("WindStart");
        player = GameObject.Find(PlayerChanger.ActivePlayer.name);
        windSpeed = 10f;
        windMult = 0f;
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
            Rigidbody otherRB = other.GetComponent<Rigidbody>();

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
            Vector3 playerForward = player.transform.forward;
            otherRB.AddForce(playerForward * windSpeed * windMult);

        }
    }
}
