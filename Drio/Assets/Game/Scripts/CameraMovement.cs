using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //[HideInInspector]
    public GameObject player;
    private float horizontalSpeed = 2.0f;
    //[HideInInspector]
    public PlayerChanger playerChanger;
    //private float verticalSpeed = 2.0f;
    private GameObject cameraHolder;
    private Transform cameraTrans;


    //56.85 rotation
    private bool canSeePlayer;
    private bool moved;
    private bool moving;

    public GameObject ray;

    private float smooth = 2.0f;
    private float holderX;

    private GameObject lastHit;


    // Start is called before the first frame update
    void Start()
    {
        playerChanger = GameObject.Find("PlayerChanger").GetComponent<PlayerChanger>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraHolder = GameObject.Find("CameraHolder");
        cameraTrans = GameObject.Find("CameraHolder").GetComponent<Transform>();
        holderX = cameraTrans.transform.rotation.x;
        lastHit = null;

        ray = GameObject.Find("Ray");
        player = PlayerChanger.ActivePlayer;
        canSeePlayer = true;
        moved = false;
        moving = false;
    }

    // Update is called once per frame
    void Update()
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
        // Mouse Input to rotate
        float h = horizontalSpeed * Input.GetAxisRaw("Mouse X");

        //float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.position = player.transform.position;


        transform.Rotate(0, h, 0);

        //if (!canSeePlayer)
        //{
        //    if(!moved)
        //    {
        //        MoveUp();
        //        if(!moving)
        //        {
        //            moved = true;
        //        }
        //    }
        //    else if(moved)
        //    {
        //        // Kameran kääntö eri akselilla
        //    }  
        //}
        //else if (canSeePlayer)
        //{
        //    if(!moved)
        //    {
        //        // Kameran kääntö normaalisti
        //    }
        //    else if(moved)
        //    {
        //        MoveBack();
        //        if(!moving)
        //        {
        //            moved = true;
        //        }
        //    }
        //}



        // Raycasting too see if player is visible
        Debug.DrawRay(ray.transform.position, player.transform.position - ray.transform.position, Color.red, 0.2f);
        RaycastHit hit;
        Ray raycast = new Ray(ray.transform.position, player.transform.position - ray.transform.position);
        if (Physics.Raycast(raycast, out hit, 200))
        {
            GameObject notPlayer = null;
            MeshRenderer rend = null;
            if (hit.collider.gameObject.tag == "Player")
            {
                canSeePlayer = true;
            }
            else if (hit.collider.gameObject.tag != "Player")
            {
                canSeePlayer = false;
                lastHit = hit.collider.gameObject;
                notPlayer = hit.transform.gameObject;
            }
            if(lastHit != null)
            {
                if (lastHit.GetComponent<MeshRenderer>().enabled == false && hit.collider.gameObject != notPlayer)
                {
                    lastHit.GetComponent<MeshRenderer>().enabled = true;
                }
            }

        }

    //void MoveUp()
    //{

    //    if (holderX < 0)
    //    {
    //        holderX = 0;
    //    }
    //    else if (holderX > 56)
    //    {
    //        holderX = 56;
    //    }

    //    if (holderX < 56f)
    //    {
    //        cameraHolder.transform.Rotate(1f, 0, 0);
    //        moving = true;
    //    }
    //    else if(holderX == 0 || holderX == 56)
    //    {
    //        moving = false;
    //    }
    //}

    //void MoveBack()
    //{

    //    if(holderX < 0)
    //    {
    //        holderX = 0;
    //    }
    //    else if(holderX > 56)
    //    {
    //        holderX = 56;
    //    }

    //    if (holderX > 0)
    //    {
    //        cameraHolder.transform.Rotate(-1, 0, 0);
    //        moving = true;
    //    }
    //    else
    //    {
    //        moving = false;
    //    }
    //}
}
}

