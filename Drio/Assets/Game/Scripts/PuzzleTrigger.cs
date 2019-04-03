using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 HOW TO USE SCRIPT:
 - This script has the ability for object movement or object rotation.
 - Attach script to any object that has collider in it and set the collider as trigger.
 - Attach the object you want to move to the "item" section.
 - For movement use the "Item Target Offset" to move the object the amount that is needed to move it (ex. x = 10 moves x position 10 on the axis).
 - Use smoothTime for how fast the object moves to the new location and back.
 - For rotation use the Rotation section, RotationDegreesPerSecond is the turn speed, ..Amount is the amount you want to rotate object and 
    ..Min is the value rotation goes back to if not triggered.
 - The script makes it that onTriggerEnter they do what is needed and onTriggerExit moves or rotates object to original position.
 - You need to give the right tags for objects depending what you want to do with them ("EarthMovable","TurningObject","MovingObject").
 - With EarthMovable you can tag triggers if only EarthDragon is able to trigger them (ex. because of his weight).
*/


public class PuzzleTrigger : MonoBehaviour
{

    // The object to move.
    public Transform item;

    // How fast movement happens
    public float smoothTime;

    // Boolean for triggers that only earth dragon can trigger
    public bool onlyEarthitem;
    public bool turningitem;
    public bool movingitem;

    // item moving
    private Vector3 velocity = Vector3.zero;
    public Vector3 itemTargetOffset;
    public Vector3 itemStart;
    public Vector3 itemTarget;
    public Vector3 itemTargetNew;

    // item rotating
    public float rotationDegreesPerSecond;
    public float rotationDegreesAmount;
    public float rotationDegreesMin;
    private float totalRotation = 0;

    void Start()
    {

        itemStart = item.transform.position;
        itemTarget = itemStart + itemTargetOffset;
        itemTargetNew = itemTarget - itemTargetOffset;

        onlyEarthitem = false;
        turningitem = false;
        movingitem = false;
    }

    private void Update()
    {
        // Earth movable items
        if (!onlyEarthitem)
        {
            MoveItemBack();
        }

        else if (onlyEarthitem)
        {
            MoveItem();
        }
        
        // Moving item
        if(!movingitem)
        {
            MoveItemBack();
        }

        else if(movingitem)
        {
            MoveItem();
        }

        // Turning items 
        if (turningitem)
        {
            if (Mathf.Abs(totalRotation) <= Mathf.Abs(rotationDegreesAmount))
            {
                SwingOpen();
            }
        }

        else if (!turningitem)
        {
            if (Mathf.Abs(totalRotation) > Mathf.Abs(rotationDegreesMin))
            {
                SwingClose();
                if (totalRotation < 0)
                {
                    totalRotation = 0;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Trigger that only Earth Dragon can activate
        if (other.gameObject.name == "EarthDragon" && item.tag == "EarthMovable")
        {
            onlyEarthitem = true;
        }

        // Trigger for turning objects
        if (other.gameObject.tag == "Player" && item.tag == "TurningObject")
        {
            turningitem = true;
        }

        // Trigger for moving objects that any player can use
        if (other.gameObject.tag == "Player" && item.tag == "MovingObject")
        {
            movingitem = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onlyEarthitem = false;
        turningitem = false;
        movingitem = false;
    }

    void SwingOpen()
    {
        float currentAngle = item.transform.rotation.eulerAngles.y;
        item.transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
        totalRotation += Time.deltaTime * rotationDegreesPerSecond;
    }
    void SwingClose()
    {
        float currentAngle = item.transform.rotation.eulerAngles.y;
        item.transform.rotation = Quaternion.AngleAxis(currentAngle - (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
        totalRotation -= Time.deltaTime * rotationDegreesPerSecond;
    }

    void MoveItem()
    {
        item.transform.position = Vector3.SmoothDamp(item.transform.position, itemTarget, ref velocity, smoothTime);
    }
    void MoveItemBack()
    {
        item.transform.position = Vector3.SmoothDamp(item.transform.position, itemTargetNew, ref velocity, smoothTime);
    }
}
