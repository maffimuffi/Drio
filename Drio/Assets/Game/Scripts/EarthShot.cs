using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShot : MonoBehaviour
{
    public GameObject ammoSpawn;
    public GameObject ammo;
    private float lastFire = 0.5f;
    public float fireRate;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Fire2") && Time.time > lastFire && PlayerChanger.CharacterSelect == 2)
        {
            sound.Play();
            lastFire = Time.time + fireRate;
            GameObject ammoInstance = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance, 0.5f);
            ammoInstance.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 15, ForceMode.Impulse);
            GameObject ammoInstance2 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance2, 0.5f);
            ammoInstance2.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 15 + transform.right * 10, ForceMode.Impulse);
            GameObject ammoInstance3 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance3, 0.5f);
            ammoInstance3.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 15 + transform.right * -10, ForceMode.Impulse);

            GameObject ammoInstance4 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance4, 0.5f);
            ammoInstance4.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 10 + transform.right * 12, ForceMode.Impulse);
            GameObject ammoInstance5 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            Destroy(ammoInstance5, 0.5f);
            ammoInstance5.GetComponent<Rigidbody>().AddForce(ammoSpawn.transform.forward * 10 + transform.right * -12, ForceMode.Impulse);

        }

       

        if (Input.GetButtonUp("Fire2") && PlayerChanger.CharacterSelect == 2)
        {
            sound.Stop();

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Smash")
        {
            
            Destroy(this.gameObject);
        }
    }

}
