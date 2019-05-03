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

    private void Awake()
    {
        windStart = GameObject.Find("WindStart");
        player = GameObject.Find(PlayerChanger.ActivePlayer.name);
        windSpeed = 10000f;
        windMult = 0f;

    }

    private void OnTriggerEnter(Collider other)
    {

        // Trigger to shut down fire
        if (other.tag == "OnFire")
        {
            // Animation?
            Destroy(other.gameObject);
        }

        // Trigger to move object with the tag WindPush with wind ability
        if (other.tag == "WindPush")
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
                windMult = 3.0f;
            }
            else if(dis < 2 && dis >= 1)
            {
                windMult = 4.0f;
            }
            else if(dis < 1)
            {
                windMult = 5.0f;
            }

            // Take the forward direction the player is facing
            Vector3 playerForward = player.transform.forward;

            // Move the object with tag WindPush
            otherRB.AddForce(playerForward * windSpeed * windMult);

        }
    }
}
