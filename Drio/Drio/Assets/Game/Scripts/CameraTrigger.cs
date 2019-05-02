using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [HideInInspector]
    public bool camTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player" || other.gameObject.layer != 9)
        {
            camTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        camTriggered = false;
    }
}
