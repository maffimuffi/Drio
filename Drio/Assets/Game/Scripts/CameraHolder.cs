using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{

    private bool hit = false;

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
           // gameObject.transform.rotation = Quaternion.Lerp(0,);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hit = true;
    }
}
