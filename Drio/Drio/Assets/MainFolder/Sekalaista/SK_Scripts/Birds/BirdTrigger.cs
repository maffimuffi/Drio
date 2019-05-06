using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTrigger : MonoBehaviour
{

    public static float triggered;

    // Start is called before the first frame update
    void Start()
    {
        triggered = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && triggered < 100)
        {
            triggered = 1;
        }
    }
}
