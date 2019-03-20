using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject character;
    float moveSpeed = 0.4f;
    float horizontalSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {       
        character = GetComponent<GameObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
   
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed;
        }
        transform.Rotate(0,h,0);
    
    }
}
