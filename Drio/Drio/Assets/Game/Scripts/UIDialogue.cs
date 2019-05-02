using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogue : MonoBehaviour
{

    
    private UITextPopup uiText;
    private bool isVisited = false;

    public string[] lines;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GameObject.Find("TextPopup").GetComponent<UITextPopup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<CharacterMovement>().IsPlayerActive())
            {
                if (!isVisited)
                {
                    isVisited = true;
                    uiText.EnterSite();
                    uiText.Dialogue(lines.Length, lines, gameObject);
                }

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<CharacterMovement>().IsPlayerActive())
            {
                //uiText.ExitSite();
                
                
            }
        }
    }
}
