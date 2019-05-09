using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamInstruction : MonoBehaviour
{

    public Camera PuzzleCam;
    public Camera mainCam;
    public GameObject firstTarget;
    float timer;
    bool Instruction;
    public static bool active;
    private AudioListener listener;
    public float individualTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        Instruction = false;
        listener = PuzzleCam.GetComponent<AudioListener>();
        listener.enabled = false;
        PuzzleCam.enabled = false;
        active = false;

    }

    void Update()
    {
        if (Instruction == true)
        {
            timer += Time.deltaTime;
            if (timer > individualTimer)
            {
                active = false;
                Instruction = false;
                timer = 0;
                mainCam.enabled = true;
                PuzzleCam.enabled = false;
                gameObject.SetActive(false);
                listener.enabled = false;
            }
            else
            {
                PuzzleCam.transform.position = Vector3.MoveTowards(PuzzleCam.transform.position, firstTarget.transform.position, 0.7f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Instruction == false)
        {
            PuzzleCam.enabled = true;
            mainCam.enabled = false;
            Instruction = true;
            listener.enabled = true;
            active = true;
            
        }
        
    }

}