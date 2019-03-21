using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private bool triggered;
    // Start is called before the first frame update
    void Awake()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!triggered)
        {
            if(other.gameObject.tag == "Player")
            {
                //Trigger();
            }
        }
    }

    private void Trigger(Collider collider)
    {
        Player_Stats player = collider.GetComponent<Player_Stats>();
        player.onDeath += OnCharacterDeath;
        triggered = true;
    }

    void OnCharacterDeath()
    {

    }
}
