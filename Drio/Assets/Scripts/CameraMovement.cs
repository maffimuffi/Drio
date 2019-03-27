using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private float horizontalSpeed = 2.0f;
    public PlayerChanger playerChanger;
    private float verticalSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.position = player.transform.position;
        
            //Debug.Log(player.name + PlayerChanger.ActivePlayer.transform.position.y);

            transform.Rotate(0, h, 0);
            
    }
}
