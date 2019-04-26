using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU : MonoBehaviour
{
    public AudioSource PUS;
    public float p;
    // Start is called before the first frame update
    void Start()
    {
        //PUS = GameObject.Find("PUSound");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HUD.amount++;
            PUS.Play();
            Destroy(this.gameObject);
        }
    }

}
