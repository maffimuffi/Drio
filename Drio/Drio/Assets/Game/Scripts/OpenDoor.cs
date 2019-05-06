using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    float speed = 5;
    float timer = 0;
    public int triggerMax;
    public static int trigger = 0;
    // Start is called before the first frame update
    void Start()
    {
        trigger = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == triggerMax) { 
        timer += Time.deltaTime;

        if (timer > 0 && timer < 4)
        {
            transform.Rotate(0, 5 * speed * Time.deltaTime, 0, Space.World);
        }
    }

        
    }


}
