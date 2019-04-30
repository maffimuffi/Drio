using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LutBrightness : MonoBehaviour
{
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (count == 3)
            {
                count = 0;
            }
            count += 1;
            if (count == 1)
            {
                TonemappingLut.adaptiveMin = 0.5f;
                TonemappingLut.adaptiveMax = 1f;
                
            }
            if (count == 2)
            {
                TonemappingLut.adaptiveMin = 1.5f;
                TonemappingLut.adaptiveMax = 2;
            }
            if (count == 3)
            {
                TonemappingLut.adaptiveMin = 0.0f;
                TonemappingLut.adaptiveMax = 0.5f;
                
            }
        }
       
    }
}
