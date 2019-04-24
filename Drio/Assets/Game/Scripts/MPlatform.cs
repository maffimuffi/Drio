using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlatform : MonoBehaviour
{
    float timer = 0;
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0 && timer < 2)
        {
            //transform.Translate(0, 0, 0.05f);
            rb.MovePosition(new Vector3(0, 0, 2));
        }

        else if (timer > 2 && timer < 4)
        {
            //transform.Translate(0, 0, -0.05f);
            rb.MovePosition(new Vector3(0, 0, 2f));
        }
    

        else if (timer > 5)
        {
            timer = 0;
        }


        

    }



}
