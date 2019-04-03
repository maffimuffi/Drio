using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{

    public Vector3 spawnPosition;

    private Transform fireDragon;
    private Transform earthDragon;
    private Transform windDragon;

    // Start is called before the first frame update
    void Awake()
    {
        spawnPosition = Checkpoint.GetActiveCheckPointPosition();

        fireDragon = GameObject.Find("FireDragon").GetComponent<Transform>();
        earthDragon = GameObject.Find("EarthDragon").GetComponent<Transform>();
        windDragon = GameObject.Find("WindDragon").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnPosition = Checkpoint.GetActiveCheckPointPosition();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "WindDragon")
        {
            Debug.Log("WindDragon damage");
            windDragon.transform.position = spawnPosition;
            // Possible Death Sound
        }

        else if (other.gameObject.name == "EarthDragon")
        {
            Debug.Log("EarthDragon damage");
            earthDragon.transform.position = spawnPosition;
            // Possible Death Sound
        }

        else if (other.gameObject.name == "FireDragon")
        {
            Debug.Log("FireDragon damage");
            fireDragon.transform.position = spawnPosition;
            // Possible Death Sound
        }
    }
}
