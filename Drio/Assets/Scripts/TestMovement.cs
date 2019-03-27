using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private float jCounter;

    private Vector3 movement;

    public float gravityScale;

    public bool grab;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float yStore = movement.y;
        movement = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        movement = movement.normalized * moveSpeed;
        movement.y = yStore;

        if (controller.isGrounded)
        {
            movement.y = 0f;
            jCounter = 0;

            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpForce;
                jCounter++;
            }
        }

        else if (!controller.isGrounded && jCounter < 2)
        {
            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpForce;
                jCounter++;
            }
        }



        movement.y = movement.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

        controller.Move(movement * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("PU"))
        {
            collision.gameObject.SetActive(false);
           
        }
    }


    }
