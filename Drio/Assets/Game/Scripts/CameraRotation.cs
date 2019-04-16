using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private bool hit = false;

    private GameObject cameraHolder;

    private Vector3 targetAngle = new Vector3(56.85f, 0, 0);
    private Vector3 startAngle;
    public Vector3 currentAngle;

    private void Start()
    {
        cameraHolder = GameObject.Find("CameraHolder");
        startAngle = cameraHolder.transform.eulerAngles;
        currentAngle = cameraHolder.transform.eulerAngles;
        //currentAngle = cameraHolder.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));


            cameraHolder.transform.eulerAngles = currentAngle;
        }

        else if (!hit)
        {
            cameraHolder.transform.eulerAngles = startAngle;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            hit = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        hit = false;
    }
}
