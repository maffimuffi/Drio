using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public static bool grab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButton("Fire2"))
        {
            grab = true;
            

        }

        else
        {
            grab = false;
        }


    }
}
