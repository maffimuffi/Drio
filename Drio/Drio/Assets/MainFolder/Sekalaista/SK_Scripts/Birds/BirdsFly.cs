using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsFly : MonoBehaviour
{
    public GameObject birds11;
    public GameObject birds12;
    public GameObject birds13;

    public GameObject birds21;
    public GameObject birds22;
    public GameObject birds23;

    public GameObject spawner;
    Vector3 spawnPos;

    private Animator anim21;
    private Animator anim22;
    private Animator anim23;

    private Animator anim11;
    private Animator anim12;
    private Animator anim13;
    float animCount;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        anim21 = birds21.gameObject.GetComponent<Animator>();
        anim22 = birds22.gameObject.GetComponent<Animator>();
        anim23 = birds23.gameObject.GetComponent<Animator>();

        anim11 = birds11.gameObject.GetComponent<Animator>();
        anim12 = birds12.gameObject.GetComponent<Animator>();
        anim13 = birds13.gameObject.GetComponent<Animator>();
        animCount = 0;
        startTime = 0;

        spawnPos = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (HUD.amount == 0)
        {
            startTime += Time.deltaTime;
            if (startTime > 0.8)
            {
                anim11.SetBool("Flying", true);
                anim12.SetBool("Flying", true);
                anim13.SetBool("Flying", true);
            }
        }
        if (HUD.amount == 2 && animCount == 0)
        {
            animCount += 1;
            anim21.SetBool("Flying", true);
            anim22.SetBool("Flying", true);
            anim23.SetBool("Flying", true);
            
            Destroy(birds12);
            Destroy(birds13);
        }
        if (HUD.amount == 3)
        {
            birds11.transform.position = spawnPos;
            if (BirdTrigger.triggered != 1 && BirdTrigger.triggered != 110)
            {
                anim11.SetBool("Flying", false);
            }
            
            Destroy(birds21);
            Destroy(birds22);
            Destroy(birds23);
        }

        if (BirdTrigger.triggered == 1)
        {
           
            
            anim11.SetBool("Flying", true);
            BirdTrigger.triggered = 110;
            
        }
        if (BirdTrigger.triggered == 2)
        {
            //Destroy(birds11);
        }
    }

}
