using System.Collections;
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
        
        if (OpenDoorAni.trigger == 5)
        {
            lastBowlLit = true;
            Debug.Log("TRUE");
        }
    }
}
