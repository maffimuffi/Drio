using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public Camera freeCamera;
    public Camera normalCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        normalCamera.enabled = true;
        freeCamera.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.U))
        {
             
            freeCamera.enabled = !freeCamera.enabled;
            normalCamera.enabled = !normalCamera.enabled;
            
        }
        }
        
    }

