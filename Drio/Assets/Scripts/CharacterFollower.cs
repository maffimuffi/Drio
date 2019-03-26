using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterFollower : MonoBehaviour
{
    [HideInInspector]
    public Transform chaseTPoint;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    private bool right;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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

            Vector3 pos = Vector3.one;
            if (right)
            {
                pos = -PlayerChanger.ActivePlayer.transform.forward * 2 +
                              PlayerChanger.ActivePlayer.transform.right * 3;
            } else if (!right)
            {
                pos = -PlayerChanger.ActivePlayer.transform.forward * 2 +
                              -PlayerChanger.ActivePlayer.transform.right * 3;
            }
            
            navMeshAgent.destination = PlayerChanger.ActivePlayer.transform.position + pos;
            
            navMeshAgent.isStopped = false;
            navMeshAgent.updateRotation = true;
            navMeshAgent.updatePosition = true;
            gameObject.GetComponent<NavMeshObstacle>().enabled = false;
        }
        else
        {
            navMeshAgent.isStopped = true;
        }
    }
}
