﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBowl : MonoBehaviour
{
    public static bool lastBowlLit;

    // Start is called before the first frame update
    void Start()
    {
        lastBowlLit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.M))
        {
            lastBowlLit = true;
            Debug.Log("TRUE");
        }
    }
}
