using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static float amount = 0;
    public float max;
    

    Text orbs;
    // Start is called before the first frame update
    void Start()
    {
        orbs = GetComponent<Text>();
        amount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        //orbs.text = "Orbs: " + amount + "/" + max;
        orbs.text = "Orbs: " + amount;
        
    }
}
