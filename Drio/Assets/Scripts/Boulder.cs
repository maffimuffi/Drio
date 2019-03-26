using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{

    public bool move;
    float moveSpeed = 0.005f;
    public GameObject player;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if(move == true)
        {
            transform.position += player.transform.forward * moveSpeed;
        }
        
    }



    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("EarthDragon"))
        {
            move = true;
        }

        else if(!other.collider.CompareTag("EarthDragon"))
        {
            move = false;
        }
    }

    void FixedUpdate()
    {
        if (move == true)
        {
            rb.AddRelativeForce(Vector3.forward * moveSpeed);
        }
        
    }

}



