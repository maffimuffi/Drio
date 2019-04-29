using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
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


    public Animator anim;
    bool isGrounded;
    bool isRunning;

    //public bool following;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lastnavMeshAgentDestination = navMeshAgent.destination;
        lastnavMeshAgentVelocity = navMeshAgent.velocity;
        lastnavMeshAgentPath = navMeshAgent.path;
        anim = GetComponent<Animator>();

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
            Vector3 direction = (PlayerChanger.ActivePlayer.transform.position - transform.position).normalized;
            if (right)
            {
                pos = -PlayerChanger.ActivePlayer.transform.forward * 8 +
                              PlayerChanger.ActivePlayer.transform.right * 10;
                
            }
            else if (!right)
            {
                pos = -PlayerChanger.ActivePlayer.transform.forward * 8 +
                              -PlayerChanger.ActivePlayer.transform.right * 10;
                

            }

            

            

            Vector3 standing = new Vector3 (0,0,0);

            if(navMeshAgent.velocity != Vector3.zero)
            {
                anim.SetBool("isRunning", true);
                isRunning = true;
            }


            else
            {
                anim.SetBool("isRunning", false);
                isRunning = false;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 30);
            }



            if (!PlayerChanger.PlayerFollowActive)
            {
                // pause();
                navMeshAgent.enabled = false;
                //navMeshAgent.isStopped = true;
                anim.SetBool("isRunning", false);
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
                Vector3 up = new Vector3(0, 0.1f, 0);
                navMeshAgent.destination = PlayerChanger.ActivePlayer.transform.position + pos + up;
                
            }

            else
            {
                //navMeshAgent.destination = transform.position;
                navMeshAgent.enabled = false;
                //            navMeshAgent.isStopped = true;
                
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
