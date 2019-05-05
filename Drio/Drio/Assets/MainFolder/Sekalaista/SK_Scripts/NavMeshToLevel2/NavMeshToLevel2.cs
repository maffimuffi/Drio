using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshToLevel2 : MonoBehaviour
{

    public GameObject spawner;
    public GameObject fireDragon;
    public GameObject earthDragon;
    public GameObject windDragon;
    public static float counter = 0;
    Vector3 position;
    
    

    void Start()
    {
        counter = 0;
        position = spawner.transform.position;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && counter == 0)
        {
            
            Debug.Log("tuleeko?");
            counter += 1;
            if (PlayerChanger.CharacterSelect == 1)
            {
                fireDragon.transform.position = position;
                earthDragon.transform.position = position;
            }
            if (PlayerChanger.CharacterSelect == 2)
            {
                fireDragon.transform.position = spawner.transform.position;
                windDragon.transform.position = spawner.transform.position;
            }
            if (PlayerChanger.CharacterSelect == 3)
            {
                windDragon.transform.position = spawner.transform.position;
                earthDragon.transform.position = spawner.transform.position;
            }
            gameObject.SetActive(false);
        }
    }
}
