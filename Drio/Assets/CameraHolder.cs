using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{

    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            //gameObject.transform.ro
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hit = true;
    }
}
