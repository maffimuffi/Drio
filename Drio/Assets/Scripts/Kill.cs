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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Damage");
            player.TakeDamage(damage);
        }
    }
}
