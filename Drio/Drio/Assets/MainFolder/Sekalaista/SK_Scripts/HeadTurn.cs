using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTurn : MonoBehaviour
{

    public GameObject camRotation;
    private float rotationZ;
    private float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationZ = camRotation.transform.rotation.z;
        rotationY = camRotation.transform.rotation.y;

        Quaternion HeadTurn = Quaternion.Euler(0, rotationY, rotationZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, HeadTurn, 5 * Time.deltaTime);
    }
}
