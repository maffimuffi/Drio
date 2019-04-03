using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{
    public GameObject ammoSpawn;
    public GameObject ammo;
    private float lastFire = 0.5f;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > lastFire && PlayerChanger.CharacterSelect == 2)
        {

            lastFire = Time.time + fireRate;
            GameObject ammoInstance = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance, 0.2f);
            ammoInstance.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 30, ForceMode.Impulse);

        }
    }
}
