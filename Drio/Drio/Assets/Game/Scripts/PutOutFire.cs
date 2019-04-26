using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOutFire : MonoBehaviour
{
    public GameObject ammo;
    bool destroy;

    //GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        //sound = GameObject.FindGameObjectWithTag("PUSound");
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy == true)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Wind"))
        {
           
            //sound.GetComponent<smashSound>().on = true;
            destroy = true;
        }
    }
}
