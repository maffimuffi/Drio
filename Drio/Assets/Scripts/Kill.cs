using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{

    public int damage;
    private Player_Stats player;

    // Start is called before the first frame update
    void Start()
    {
        damage = 666;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }
}
