﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBreath : MonoBehaviour
{
    public GameObject ammoSpawn;
    public GameObject ammo;
    public CapsuleCollider capsule;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        capsule = ammo.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerChanger.CharacterSelect == 1)
        {
            if (Input.GetButton("Fire2"))
            {

                GameObject ammoInstance = Instantiate(ammo, ammoSpawn.transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                Destroy(ammoInstance, 0.02f);
                ammoInstance.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 15, ForceMode.Impulse);
            }
        }

        if (Input.GetButtonDown("Fire2") && PlayerChanger.CharacterSelect == 1)
        {
            sound.Play();




        }

        if (Input.GetButtonUp("Fire2") && PlayerChanger.CharacterSelect == 1)
        {
            sound.Stop();

        }

        if(PlayerChanger.CharacterSelect != 1)
        {
            sound.Stop();
        }

    }
}
