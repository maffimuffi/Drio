using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMoveTest : MonoBehaviour
{

    public Transform obstacle;

    public PlayerChanger changer;

    // How fast movement happends
    public float smoothTime;

    // Obstacle turning
    

    // Boolean for triggers that only earth dragon can trigger
    public bool onlyEarthTrigger;
    public bool turningObstacle;

    // Obstacle moving
    private Vector3 velocity = Vector3.zero;
    public Vector3 obstacleTargetOffset;
    public Vector3 obstacleStart;
    public Vector3 obstacleTarget;
    public Vector3 obstacleTargetNew;

    // Obstacle rotating


    void Start()
    {

        obstacleStart = obstacle.transform.position;
        obstacleTarget = obstacleStart + obstacleTargetOffset;
        obstacleTargetNew = obstacleTarget - obstacleTargetOffset;

        changer = GameObject.Find("PlayerChanger").GetComponent<PlayerChanger>();
        onlyEarthTrigger = false;
    }

    private void Update()
    {
        if(!onlyEarthTrigger)
        {
            obstacle.transform.position = Vector3.SmoothDamp(obstacle.transform.position, obstacleTargetNew, ref velocity, smoothTime);
        }

        else if(onlyEarthTrigger)
        {
            obstacle.transform.position = Vector3.SmoothDamp(obstacle.transform.position, obstacleTarget, ref velocity, smoothTime);
        }

        if(!turningObstacle)
        {
            Quaternion backRotation = Quaternion.AngleAxis(0, Vector3.up);
            obstacle.transform.rotation = Quaternion.Slerp(transform.rotation, backRotation, 0.2f);
        }
        else if(turningObstacle)
        {
            Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.up);
            obstacle.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speed);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Trigger that only Earth Dragon can activate
        if (other.gameObject.name == "EarthDragon" && obstacle.tag == "MovingPlatform")
        {
            onlyEarthTrigger = true;
        }
        
        if(other.gameObject.tag == "Player" && obstacle.tag == "Door")
        {
            turningObstacle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onlyEarthTrigger = false;
        turningObstacle = false;
    }

}
