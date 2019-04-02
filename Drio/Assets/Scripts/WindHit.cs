using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindHit : MonoBehaviour
{

    // Animation stuff

    // Trigger to shut down fire
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "onFire")
        {
            // Animation?
            Destroy(other.gameObject);
        }
    }
}
