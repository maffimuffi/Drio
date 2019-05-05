using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPush : MonoBehaviour{

    public Rigidbody rb;

    public float moveX;
    public float moveZ;

    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        



        

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Wind"))
        {
            rb.isKinematic = false;
            transform.position = new Vector3(moveX, 0, moveZ);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Wind"))
        {
            rb.isKinematic = true;
        }
    }

}
