using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public GameObject RaycastOrigin;
    public LayerMask mask;
    public GameObject bone;
    float rotation;
    float smooth;

    public float TimeSpeed;
    public float RotateIncrease;
    // Start is called before the first frame update
    void Start()
    {
        smooth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
        if (hit.distance > 0.8f && hit.distance < 1.6f)
        {
            
            bone.transform.localRotation = Quaternion.Euler(1.7f, bone.transform.rotation.y, bone.transform.rotation.z);
        }
        else if (hit.distance > 1.6f)
        {
            rotation = (hit.distance*RotateIncrease)/hit.distance;
            
            bone.transform.localRotation = Quaternion.Slerp(bone.transform.localRotation, Quaternion.Euler(rotation, bone.transform.localRotation.y, bone.transform.localRotation.z), TimeSpeed * Time.deltaTime);
        }
        else if (hit.distance < 0.8f)
        {
            rotation = (-hit.distance * RotateIncrease)/hit.distance;
            
            bone.transform.localRotation = Quaternion.Slerp(bone.transform.localRotation, Quaternion.Euler(rotation, bone.transform.localRotation.y, bone.transform.localRotation.z), TimeSpeed * Time.deltaTime);
            
            
        }
        Debug.Log("Ei rotatoida" + hit.distance);
    }
}
