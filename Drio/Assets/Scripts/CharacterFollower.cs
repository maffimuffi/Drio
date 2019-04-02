using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterFollower : MonoBehaviour
{
    [HideInInspector]
    public Transform chaseTPoint;
    [HideInInspector]
    private NavMeshAgent navMeshAgent;

    private NavMeshPath lastnavMeshAgentPath;
    private Vector3 lastnavMeshAgentVelocity;
    private Vector3 lastnavMeshAgentDestination;
    private bool right;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lastnavMeshAgentDestination = navMeshAgent.destination;
        lastnavMeshAgentVelocity = navMeshAgent.velocity;
        lastnavMeshAgentPath = navMeshAgent.path;
       
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    void Chase()
    {
       
        if (gameObject != PlayerChanger.ActivePlayer)
        {
            if (PlayerChanger.CharacterSelect == 1)
            {
                if (gameObject.name == "FireDragon")
                {
                    newPosition = new Vector3(-3f, 0.5f, -2f);
                    right = false;
                }
                else if (gameObject.name == "EarthDragon")
                {
                    right = true;
                    newPosition = new Vector3(3f, 0.5f, -2f);
                }

            }
            else if (PlayerChanger.CharacterSelect == 2)
            {
                if (gameObject.name == "FireDragon")
                {
                    right = false;
                    newPosition = new Vector3(-3f, 0.5f, -2f);
                }
                else if (gameObject.name == "WindDragon")
                {
                    right = true;
                    newPosition = new Vector3(3f, 0.5f, -2f);
                }
            }
            else if (PlayerChanger.CharacterSelect == 3)
            {
                if (gameObject.name == "WindDragon")
                {
                    right = false;
                    newPosition = new Vector3(-3f, 0.5f, -2f);
                }
                else if (gameObject.name == "EarthDragon")
                {
                    right = true;
                    newPosition = new Vector3(3f, 0.5f, -2f);
                    
                }
            }

            Vector3 pos = gameObject.transform.position;
            if (right)
            {
                pos = -PlayerChanger.ActivePlayer.transform.forward * 2 +
                              PlayerChanger.ActivePlayer.transform.right * 3;
            } else if (!right)
            {
                pos = -PlayerChanger.ActivePlayer.transform.forward * 2 +
                              -PlayerChanger.ActivePlayer.transform.right * 3;
            }

            
           
            if(!PlayerChanger.PlayerFollowActive)
            {
               // pause();
                navMeshAgent.enabled = false;
                //navMeshAgent.isStopped = true;
            }
            if (PlayerChanger.PlayerFollowActive)
            {
                navMeshAgent.enabled = true;
                //navMeshAgent.isStopped = false;
                gameObject.GetComponent<NavMeshObstacle>().enabled = false;
                //navMeshAgent.path.corners[0] = gameObject.transform.position;
            }

            if (navMeshAgent.enabled)
            {
                navMeshAgent.destination = PlayerChanger.ActivePlayer.transform.position + pos;
            }
        }
        else
        {
            //navMeshAgent.destination = transform.position;
            navMeshAgent.enabled = false;
//            navMeshAgent.isStopped = true;
        }
    }
   
}
