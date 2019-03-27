using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    public GameObject player;
    public bool works;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player){
            player.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }

    }



}
