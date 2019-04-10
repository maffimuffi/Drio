using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static float amount = 0;
    Text orbs;
    // Start is called before the first frame update
    void Start()
    {
        orbs = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        orbs.text = "Orbs: " + amount + "/15";
    }
}
