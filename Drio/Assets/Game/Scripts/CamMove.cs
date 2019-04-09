using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    public bool lockCursor;
    public float mouseSensetivity = 10;
    public Transform target;
    public float distFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;


    [Header("Collision Vars")]

    [Header("Transparency")]
    public bool changeTransparency = true;
    public MeshRenderer targetRenderer;

    [Header("Speeds")]
    public float moveSpeed = 5;
    public float returnSpeed = 9;
    public float wallPush = 8f;

    [Header("Distances")]
    public float closestDistanceToPlayer = 2;
    public float evenCloserDistanceToPlayer = 1;

    [Header("Mask")]
    public LayerMask collisionMask;

    private bool pitchLock = false;


    // Use this for initialization
    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
       

    }

    // Update is called once per frame
    void LateUpdate()
    {

        CollisionCheck(target.position - transform.forward * distFromTarget + transform.up * distFromTarget / 2);
        wallCheck();

        if (!pitchLock)
        {

            yaw += Input.GetAxis("Mouse X") * mouseSensetivity;
            pitch += Input.GetAxis("Mouse Y") * mouseSensetivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
            currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);

        }

        else
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensetivity;
            pitch = pitchMinMax.y;

            currentRotation = Vector3.Lerp(currentRotation, new Vector3(pitch, yaw), rotationSmoothTime * Time.deltaTime);
        }

        //currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation;

        //Vector3 e = transform.eulerAngles;
        //e.x = 0;

        //target.eulerAngles = e;


    }

    private void wallCheck()
    {
        Ray ray = new Ray(target.position, -target.forward);
        RaycastHit hit;

        if(Physics.SphereCast (ray, 0.2f, out hit, 0.7f, collisionMask))
        {
            pitchLock = true;
        }

        else
        {
            pitchLock = false;
        }
    }

    private void CollisionCheck (Vector3 retPoint)
    {

        RaycastHit hit;

        if (Physics.Linecast(target.position, retPoint, out hit, collisionMask))
        {
            Vector3 norm = hit.normal * wallPush;
            Vector3 p = hit.point + norm;

            TransparencyCheck();

            if(Vector3.Distance (Vector3.Lerp (transform.position, p, moveSpeed * Time.deltaTime), target.position) <= evenCloserDistanceToPlayer)
            {

            }

            else
            {
                transform.position = Vector3.Lerp(transform.position, p, moveSpeed * Time.deltaTime);
            }

            return;

        }

        FullTransparency();

        transform.position = Vector3.Lerp(transform.position, retPoint, returnSpeed * Time.deltaTime);
        pitchLock = false;


    }

    private void TransparencyCheck()
    {

        if (changeTransparency)
        {
            if(Vector3.Distance (transform.position, target.position) <= closestDistanceToPlayer)
            {

                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.Lerp(temp.a, 0.2f, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;

                
            }

            else
            {
                if(targetRenderer.sharedMaterial.color.a <= 0.99f)
                {
                    Color temp = targetRenderer.sharedMaterial.color;
                    temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

                    targetRenderer.sharedMaterial.color = temp;

                }
            }

        }

    }

    private void FullTransparency()
    {
        if (changeTransparency)
        {
            if (targetRenderer.sharedMaterial.color.a <= 0.99f)
            {
                Color temp = targetRenderer.sharedMaterial.color;
                temp.a = Mathf.Lerp(temp.a, 1, moveSpeed * Time.deltaTime);

                targetRenderer.sharedMaterial.color = temp;

            }
        }

    }

}
