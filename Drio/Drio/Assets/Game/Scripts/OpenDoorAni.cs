using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAni : MonoBehaviour
{
    public int triggerMax;
    public static int trigger2 = 0;
    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("openDoor", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(trigger);
        if (trigger2 == triggerMax)
        {
            Debug.Log(trigger2);
            anim.SetBool("OpenDoor", true);
        }


    }
}
