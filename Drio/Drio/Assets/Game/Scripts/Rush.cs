using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            if(PlayerChanger.CharacterSelect == 3)
            {
                CharacterMovement.moveSpeed = 12;
            }
            
        }

        else
        {
            CharacterMovement.moveSpeed = 8;
        }
    }
}
