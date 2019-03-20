using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject character;
    
    //public GameObject cameraRotator;
    float moveSpeed = 0.4f;
    float horizontalSpeed = 2.0f;
    //float verticalSpeed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //katsotaan character gameobjectista
        character = GetComponent<GameObject>();
      
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
    //    float v = verticalSpeed * Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed;
        }
        transform.Rotate(0,h,0);
     //kommentoitu kameran liikutus
        //   Debug.Log(v);
        //   cameraRotator.transform.Rotate(v,0,0);
    }
}
