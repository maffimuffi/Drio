using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    // Is checkpoint activated
    public bool Activated = false;

    public static Vector3 originalPos;

    private GameObject player;

    private Animator thisAnimator;

    
    // List with all checkpoints in the scene
    public static GameObject[] CheckPointsList;


    /// Get position of the last activated checkpoint
    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = originalPos;

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<Checkpoint>().Activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }

    /// Activate the checkpoint
    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<Checkpoint>().Activated = false;
            cp.GetComponent<Animator>().SetBool("Active", false);
        }

        // We activated the current checkpoint
        Activated = true;
        thisAnimator.SetBool("Active", true);
    }

    void Start()
    {
        thisAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        originalPos = player.transform.position;

        // We search all the checkpoints in the current scene
        CheckPointsList = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }
}
