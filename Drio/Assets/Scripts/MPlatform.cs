using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlatform : MonoBehaviour
{
    float timer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0 && timer < 2)
        {
            transform.Translate(0, 0, 0.05f);
        }

        else if (timer > 2 && timer < 4)
        {
            transform.Translate(0, 0, -0.05f);
        }

        else if (timer > 5)
        {
            timer = 0;
        }
    }

}
