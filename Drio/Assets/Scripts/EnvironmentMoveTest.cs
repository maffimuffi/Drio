using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMoveTest : MonoBehaviour
{

    public Transform obstacle;

    //public float moveTime = 2;
    public float smoothTime = 0.5f;

    public bool onTrigger;

    private Vector3 velocity = Vector3.zero;
    public Vector3 obstacleTargetOffset;
    public Vector3 obstacleStart;
    public Vector3 obstacleTarget;
    public Vector3 obstacleTargetNew;

    void Start()
    {
        obstacleStart = obstacle.transform.position;
        obstacleTarget = obstacleStart + obstacleTargetOffset;
        obstacleTargetNew = obstacleTarget - obstacleTargetOffset;
        onTrigger = false;
    }

    private void Update()
    {
        if(!onTrigger)
        {
            obstacle.transform.position = Vector3.SmoothDamp(obstacle.transform.position, obstacleTargetNew, ref velocity, smoothTime);
        }

        else if(onTrigger)
        {
            obstacle.transform.position = Vector3.SmoothDamp(obstacle.transform.position, obstacleTarget, ref velocity, smoothTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }

}
