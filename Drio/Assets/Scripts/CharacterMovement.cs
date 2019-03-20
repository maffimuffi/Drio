using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    float moveSpeed = 0.4f;
    float jumpSpeed = 5f;
    private float rotateSpeed = 5f;
    public GameObject playerTransform;
    
    // Start is called before the first frame update
    void Start()
    {       
        
    }

    // Update is called once per frame
    void Update()
    {
        
   
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += playerTransform.transform.forward * moveSpeed;
            transform.rotation = playerTransform.transform.rotation;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -playerTransform.transform.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -playerTransform.transform.right * moveSpeed;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += playerTransform.transform.right * moveSpeed;
        }
       
        //RaycastHit ground;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //not working
            /*Debug.DrawRay(transform.position,Vector3.down,Color.red,0.2f);
            Debug.Log(Physics.Raycast(transform.position, Vector3.down, out ground, 0.2f));
            if (Physics.Raycast(transform.position, Vector3.down, out ground, 0.2f))
            {*/
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            //}
        }
    }
}
