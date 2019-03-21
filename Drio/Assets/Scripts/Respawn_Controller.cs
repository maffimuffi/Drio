using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Controller : MonoBehaviour
{

    public Checkpoint respawningCheckpoint = null;

    public delegate void MyDelegate();
    public event MyDelegate onRespawn;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Awake()
    {
        initialPosition = transform.position;
        //respawningCheckpoint.o
        
    }

    public void OnRespawn()
    {
        transform.position = initialPosition;
        onRespawn();
    }
}
