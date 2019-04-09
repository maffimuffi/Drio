using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    public GameObject ammoSpawn;
    public GameObject ammo;
    private float lastFire = 0.5f;
    public float fireRate;
    public AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButton("Fire2") && Time.time > lastFire && PlayerChanger.CharacterSelect == 3)
        {

            lastFire = Time.time + fireRate;
            GameObject ammoInstance = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance, 0.4f);
            ammoInstance.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 10, ForceMode.Impulse);
            GameObject ammoInstance2 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance2, 0.4f);
            ammoInstance2.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 10 + transform.right * 0.5f, ForceMode.Impulse);
            GameObject ammoInstance3 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance3, 0.4f);
            ammoInstance3.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 10 + transform.right * -0.5f, ForceMode.Impulse);

            

        }

        if (Input.GetButtonDown("Fire2") && PlayerChanger.CharacterSelect == 3)
        {
            fireSound.Play();
        }

        if (Input.GetButtonUp("Fire2") && PlayerChanger.CharacterSelect == 3)
        {
            fireSound.Stop();
        }

    }
}
