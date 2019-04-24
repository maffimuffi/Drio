using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private GameObject player;
    private Camera cam;

    private float horizontalSpeed = 2.0f;
    private float smoothTime = 0.4f;

    private PlayerChanger playerChanger;
    private CameraTrigger cameraTrigger;

    private Transform playerTrans;
    private Transform cameraTrans;
    private Transform cameraPos1;
    private Transform cameraPos2;

    //56.85 rotation
    private bool canSeePlayer;

    private GameObject defaultCameraPos;

    [HideInInspector]
    public RaycastHit hit;

    private Vector3 velocity = Vector3.zero;

    public LayerMask myLayerMask;


    // Start is called before the first frame update
    void Start()
    {

        //cam.transform.position = cameraPos1.transform.position;
        defaultCameraPos = GameObject.Find("DefaultPos");
        player = PlayerChanger.ActivePlayer;
        canSeePlayer = true;

        playerChanger = GameObject.Find("PlayerChanger").GetComponent<PlayerChanger>();
        cameraTrigger = GameObject.Find("DefaultPos").GetComponent<CameraTrigger>();
        Cursor.lockState = CursorLockMode.Locked;
        playerTrans = player.GetComponent<Transform>();
        cameraTrans = GameObject.Find("Cam").GetComponent<Transform>();

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

        // Check if raycast can see player or default position hits a wall, move camera on top of player
        if(!canSeePlayer || cameraTrigger.camTriggered == true)
        {
            // Camera movement to up position
            cameraTrans.transform.position = Vector3.SmoothDamp(cameraTrans.transform.position, cameraPos2.transform.position, ref velocity, smoothTime);

            // Camera rotation
            cameraTrans.transform.rotation = cameraPos2.transform.rotation;
        }
        // Check if raycast can see player and default position isn't hitting a wall, move the camera to default position
        else if(canSeePlayer && cameraTrigger.camTriggered == false)
        {
            // Camera movement to default position
            cameraTrans.transform.position = Vector3.SmoothDamp(cameraTrans.transform.position, cameraPos1.transform.position, ref velocity, smoothTime);
        }



        // defaultCameraPoscasting too see if player is visible
        Debug.DrawRay(defaultCameraPos.transform.position, player.transform.position - defaultCameraPos.transform.position, Color.red, 0.2f);
        Ray raycast = new Ray(defaultCameraPos.transform.position, player.transform.position - defaultCameraPos.transform.position);
        if (Physics.Raycast(raycast, out hit, 200, myLayerMask))
        {
            // || hit.collider.gameObject.tag == "Wind" || hit.collider.gameObject.tag == "EarthShot" || hit.collider.gameObject.tag == "FireShot"
            if (hit.collider.gameObject.tag == "Player")
            {
                canSeePlayer = true;
            }
            else if (hit.collider.gameObject.tag != "Player")
            {
                canSeePlayer = false;
            }

        }
    }
}

