using System.Collections;
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
    
    

    // Start is called before the first frame update
    void Start()
    {
        intensity = directionalLight.intensity;
        lastBowlLit = false;
        lastLight.SetActive(false);
        
        
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

        if (OpenDoorAni.trigger2 == 5)
        {
            
            lastBowlLit = true;
        }
    }
}
