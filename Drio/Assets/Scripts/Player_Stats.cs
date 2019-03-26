﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{

    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int takenDamage)
    {
        hp -= takenDamage;
    }

    void Die()
    {
        gameObject.transform.position = Checkpoint.GetActiveCheckPointPosition();
    }
}
