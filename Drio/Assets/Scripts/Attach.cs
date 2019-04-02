using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
            player.transform.parent = transform;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            player.transform.parent = null;
    }



}
