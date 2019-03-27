using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{

    private GameObject fireDragon;
    private GameObject earthDragon;
    private GameObject windDragon;

    private Player_Stats fireStats;
    private Player_Stats earthStats;
    private Player_Stats windStats;

    // Start is called before the first frame update
    void Start()
    {
        fireDragon = GameObject.Find("FireDragon");
        earthDragon = GameObject.Find("EarthDragon");
        windDragon = GameObject.Find("WindDragon");

        fireStats = fireDragon.GetComponent<Player_Stats>();
        earthStats = earthDragon.GetComponent<Player_Stats>();
        windStats = windDragon.GetComponent<Player_Stats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FireDragon")
        {
            Debug.Log("FireDragon Damage");
            fireStats.TakeDamage();
        }

        else if(other.gameObject.name == "EarthDragon")
        {
            Debug.Log("EarthDragon Damage");
            earthStats.TakeDamage();
        }

        else if(other.gameObject.name == "WindDragon")
        {
            Debug.Log("WindDragon Damage");
            windStats.TakeDamage();
        }
    }
}
