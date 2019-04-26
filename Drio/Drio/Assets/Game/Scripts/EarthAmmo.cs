using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Smash")
        {

            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Terrain")
        {

            Destroy(this.gameObject);
        }

    }

}
