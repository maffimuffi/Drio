using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    //56.85 rotation
    private bool canSeePlayer;

    private GameObject cam;
    private GameObject player;

    private float smooth = 3.0f;

    private Quaternion upRotation;
    private Quaternion ogRot;

    private void Start()
    {
        cam = GameObject.Find("Cam");
        player = PlayerChanger.ActivePlayer;
        canSeePlayer = true;
        ogRot = this.transform.rotation;
        upRotation = new Quaternion(ogRot.x + 56.85f, ogRot.y, ogRot.z, ogRot.w);
    }

    // Update is called once per frame
    void Update()
    {
        player = PlayerChanger.ActivePlayer;

        if (canSeePlayer)
        {
            //this.transform.rotation = ogRot;
        }
        else if (!canSeePlayer)
        {
           // this.transform.rotation = Quaternion.Lerp(ogRot, upRotation, smooth);
        }

        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.position - player.transform.position, out hit, 5))
        {
            if(hit.transform == player)
            {
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
    } 
}
