using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsOptimizer : MonoBehaviour
{
    public GameObject Scene2Objects;
    public GameObject SecondGateObjects;
    public GameObject FirstGateObjects;
   
    



    // Start is called before the first frame update
    void Start()
    {
        Scene2Objects.SetActive(false);
        SecondGateObjects.SetActive(false);
        FirstGateObjects.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Scene2Objects.SetActive(true);
            SecondGateObjects.SetActive(true);
            FirstGateObjects.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            FirstGateObjects.SetActive(true);
            Scene2Objects.SetActive(false);
            SecondGateObjects.SetActive(false);
        }
        if (OpenDoorAni.trigger == 1)
        {
            
            Scene2Objects.SetActive(true);
            SecondGateObjects.SetActive(true);
            //FirstGateObjects.SetActive(false);
        }
        
    }
    
}
