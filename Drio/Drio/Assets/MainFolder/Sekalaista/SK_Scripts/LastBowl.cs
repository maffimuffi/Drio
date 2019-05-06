﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBowl : MonoBehaviour
{
    public static bool lastBowlLit;
    public GameObject lastLight;
    float lightTime;
    float thunderTime;
    public Light directionalLight;
    float intensity;
    
    public GameObject thunderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        intensity = directionalLight.intensity;
        lastBowlLit = false;
        lastLight.SetActive(false);
        thunderPrefab.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HUD.amount == 32)
        {
            lightTime += Time.deltaTime;
            
            if (lightTime < 2)
            {
                
                directionalLight.intensity = 0;
                lastLight.SetActive(true);
            }
            else
            {
                directionalLight.intensity = intensity;
                lastLight.SetActive(false);
            }

        }

        if (OpenDoor.trigger == 5)
        {
            thunderTime += Time.deltaTime;
            if (thunderTime < 0.5)
            {
                thunderPrefab.SetActive(true);
                directionalLight.intensity = 0;
            }
            else
            {
                directionalLight.intensity = intensity;
                thunderPrefab.SetActive(false);
            }
            lastBowlLit = true;
        }
    }
}
