using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMoveTest : MonoBehaviour
{

    public Transform rock;

    //public float moveTime = 2;
    public float smoothTime = 0.5f;

    public bool onTrigger;

    private Vector3 velocity = Vector3.zero;
    public Vector3 rockTargetOffset;
    public Vector3 rockStart;
    public Vector3 rockTarget;
    public Vector3 rockTargetNew;

    void Start()
    {
        rockStart = rock.transform.position;
        rockTarget = rockStart + rockTargetOffset;
        rockTargetNew = rockTarget - rockTargetOffset;
        onTrigger = false;
    }

    private void Update()
    {
        if(!onTrigger)
        {
            rock.transform.position = Vector3.SmoothDamp(rock.transform.position, rockTargetNew, ref velocity, smoothTime);
        }

        else if(onTrigger)
        {
            rock.transform.position = Vector3.SmoothDamp(rock.transform.position, rockTarget, ref velocity, smoothTime);
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
