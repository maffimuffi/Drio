using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Trigger : MonoBehaviour

{
    public GameObject FirstGateObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstGateObjects.SetActive(false);
            Debug.Log("toimiiii");
        }
    }
}
