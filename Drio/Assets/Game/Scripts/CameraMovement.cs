using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private GameObject player;
    private Camera cam;

    private float horizontalSpeed = 2.0f;

    private PlayerChanger playerChanger;

    private Transform playerTrans;
    private Transform cameraTrans;
    private Transform cameraPos1;
    private Transform cameraPos2;

    //56.85 rotation
    private bool canSeePlayer;
    private bool moved;

    private GameObject ray;
    private GameObject lastHit;


    // Start is called before the first frame update
    void Start()
    {

        //cam.transform.position = cameraPos1.transform.position;
        ray = GameObject.Find("Ray");
        player = PlayerChanger.ActivePlayer;
        canSeePlayer = true;
        moved = false;

        playerChanger = GameObject.Find("PlayerChanger").GetComponent<PlayerChanger>();
        Cursor.lockState = CursorLockMode.Locked;
        playerTrans = player.GetComponent<Transform>();
        cameraTrans = GameObject.Find("Cam").GetComponent<Transform>();
        lastHit = null;

        cameraPos1 = GameObject.Find("DefaultPos").GetComponent<Transform>();
        cameraPos2 = GameObject.Find("UpPos").GetComponent<Transform>();


    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerChanger.CharacterSelect == 1)
        {
            player = GameObject.Find("WindDragon");
        }
        else if (PlayerChanger.CharacterSelect == 2)
        {
            player = GameObject.Find("EarthDragon");
        }
        else if (PlayerChanger.CharacterSelect == 3)
        {
            player = GameObject.Find("FireDragon");
        }
        else
        {
            Debug.Log("ERROR 404");
        }

        playerTrans = player.GetComponent<Transform>();

        // Mouse Input to rotate
        float h = horizontalSpeed * Input.GetAxisRaw("Mouse X");


        //float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.position = player.transform.position;

        cameraTrans.transform.LookAt(playerTrans);

        transform.Rotate(0, h, 0);

        if(!canSeePlayer)
        {
            cameraTrans.transform.position = cameraPos2.transform.position;
            cameraTrans.transform.rotation = cameraPos2.transform.rotation;
            //if(!moved)
            //{
            //    MoveTowards();
            //}
        }
        else if(canSeePlayer)
        {
            cameraTrans.transform.position = cameraPos1.transform.position;
            //if(moved)
            //{
            //    MoveBack();
            //}
        }



        // Raycasting too see if player is visible
        Debug.DrawRay(ray.transform.position, player.transform.position - ray.transform.position, Color.red, 0.2f);
        RaycastHit hit;
        Ray raycast = new Ray(ray.transform.position, player.transform.position - ray.transform.position);
        if (Physics.Raycast(raycast, out hit, 200))
        {
            //GameObject notPlayer = null;
            if (hit.collider.gameObject.tag == "Player")
            {
                canSeePlayer = true;
            }
            else if (hit.collider.gameObject.tag != "Player")
            {
                canSeePlayer = false;
                //lastHit = hit.collider.gameObject;
                //notPlayer = hit.transform.gameObject;
            }
            //if(lastHit != null)
            //{
            //    if (lastHit.GetComponent<MeshRenderer>().enabled == false && hit.collider.gameObject != notPlayer)
            //    {
            //        lastHit.GetComponent<MeshRenderer>().enabled = true;
            //    }
            //}

        }

        //void MoveTowards()
        //{
            
        //    moved = true;
        //}

        //void MoveBack()
        //{

            
        //}
    }
}

