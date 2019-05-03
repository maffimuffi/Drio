using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDown : MonoBehaviour
{

    bool isGoingDown;
    float down = -7.7f;
    public GameObject otherBlock;
    Vector3 targetPosition;
    Vector3 otherBlockTPos;
    // Start is called before the first frame update
    void Start()
    {
        isGoingDown = false;
        targetPosition = new Vector3(transform.position.x, -50f, transform.position.z);
        otherBlockTPos = new Vector3(otherBlock.transform.position.x, -30f, otherBlock.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoingDown == true)
        {
            down -= Time.deltaTime;
            transform.position = transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.05f);
            otherBlock.transform.position = Vector3.MoveTowards(otherBlock.transform.position, otherBlockTPos, 0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            isGoingDown = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        isGoingDown = false;
        
    }
}
