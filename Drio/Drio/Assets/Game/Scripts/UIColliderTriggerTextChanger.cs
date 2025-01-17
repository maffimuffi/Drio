﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColliderTriggerTextChanger : MonoBehaviour
{
   
    public string uiTextObject;
    private UITextPopup uiText;
    
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
                if (uiText.isDialogueWaiting || uiText.dialogueActive)
                {
                    uiText.DialoguePause();
                    uiText.PriorityText();
                    uiText.TextChange(uiTextObject);

                }
                else
                {
                    
                    uiText.PriorityText();
                    uiText.TextChange(uiTextObject);
                    uiText.EnterSite();
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
                if (uiText.isDialogueWaiting && !uiText.dialogueActive)
                {
                    uiText.DialogueContinue();
                } else if (uiText.dialogueActive)
                {
                    
                }
                else
                {
                    uiText.ExitSite();
                }
            }
        }
    }
}
