﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //[HideInInspector]
    public GameObject player;
    private float horizontalSpeed = 2.0f;
    //[HideInInspector]
    public PlayerChanger playerChanger;
    private float verticalSpeed = 2.0f;


   

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        

    }

    // Update is called once per frame
    void Update()
    {
        // playerChanger = GameObject.Find("PlayerChanger").GetComponent<PlayerChanger>();
        if (PlayerChanger.CharacterSelect == 1)
        {
            player = GameObject.Find("WindDragon");
            //Debug.Log("Wind");
        }
        else if (PlayerChanger.CharacterSelect == 2)
        {
            player = GameObject.Find("EarthDragon");
            //Debug.Log("Earth");
        }
        else if (PlayerChanger.CharacterSelect == 3)
        {
            //Debug.Log("Fire");
            player = GameObject.Find("FireDragon");
        }
        else
        {
            Debug.Log("ei löydy");
        }

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.position = player.transform.position;
        
            //Debug.Log(player.name + PlayerChanger.ActivePlayer.transform.position.y);

            transform.Rotate(0, h, 0);

        
    } 

    

}

