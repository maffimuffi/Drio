using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_PU : MonoBehaviour
{
    public static float amount = 0;
    public float max;
    Text Pup;

    // Start is called before the first frame update
    void Start()
    {
        Pup = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Pup.text = "Orbs: " + amount + " /" + max;
    }
}
