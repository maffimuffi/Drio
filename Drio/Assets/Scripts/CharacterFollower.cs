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
        Debug.Log("this " + gameObject.name);
        //Debug.Log("nottthis " + PlayerChanger.ActivePlayer.name);
        if (gameObject != PlayerChanger.ActivePlayer)
        {
            if (PlayerChanger.CharacterSelect == 1)
            {
                if (gameObject.name == "FireDragon")
                {
                    newPosition = new Vector3(-3f, 0.5f, -2f);
                }
                else if (gameObject.name == "EarthDragon")
                {
                    newPosition = new Vector3(3f, 0.5f, -2f);
                }

            }
            else if (PlayerChanger.CharacterSelect == 2)
            {
                if (gameObject.name == "FireDragon")
                {
                    newPosition = new Vector3(-3f, 0.5f, -2f);
                }
                else if (gameObject.name == "WindDragon")
                {
                    newPosition = new Vector3(3f, 0.5f, -2f);
                }
            }
            else if (PlayerChanger.CharacterSelect == 3)
            {
                if (gameObject.name == "WindDragon")
                {
                    newPosition = new Vector3(-3f, 0.5f, -2f);
                }
                else if (gameObject.name == "EarthDragon")
                {
                    newPosition = new Vector3(3f, 0.5f, -2f);
                }
            }

            Debug.Log("Liikutaan");
            navMeshAgent.destination = PlayerChanger.ActivePlayer.transform.position + newPosition;
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
