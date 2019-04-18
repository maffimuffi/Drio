using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITextPopup : MonoBehaviour
{
    private RawImage backroundMat;
    private bool entering;
    private bool entered;
    
    private float popupCounter;
    
    public float exitCounter = 0;
    private float exitTimeMax = 10;
    private float maxTime = 1;
    private float popupSpeed = 0.1f;
    private float popupSpeed2 = 0.2f;
    private float maxTransperency;
    private float transperencyChangeSpeed;
    private bool exiting;
    private TextMeshProUGUI text;
    private float maxSize = 1;
   
    private float minSize = 0.5f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        popupCounter = 0;
        backroundMat = GetComponent<RawImage>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        
        
        
        
        backroundMat.transform.localScale =
            new Vector3(backroundMat.transform.localScale.x -1 + minSize,
                backroundMat.transform.localScale.y -1 + minSize, 0);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (entering && !exiting)
        {
            popupCounter += Time.deltaTime;
            
            backroundMat.transform.localScale =
                new Vector3(backroundMat.transform.localScale.x + popupCounter * popupSpeed2,
                        backroundMat.transform.localScale.y + popupCounter * popupSpeed2, 0);
            
            if (popupCounter >= maxTime || backroundMat.transform.localScale.x >= maxSize)
            {
                backroundMat.transform.localScale =
                new Vector3(maxSize,maxSize, 0);
                entering = false;
                entered = true;
                popupCounter = 0; 
            }
        }

        if (exiting && (entering || entered))
        {
            popupCounter += Time.deltaTime;
            if (popupCounter > maxTime / 2)
            {
                backroundMat.transform.localScale =
                    new Vector3(backroundMat.transform.localScale.x - popupCounter * popupSpeed,
                        backroundMat.transform.localScale.y - popupCounter * popupSpeed, 0);
            }

            if (popupCounter >= maxTime || backroundMat.transform.localScale.x <= minSize)
            {
                backroundMat.transform.localScale =
                    new Vector3(minSize,
                        minSize, 0);
                entered = false;
                entering = false;
                exiting = false;
                popupCounter = 0;
                gameObject.SetActive(false);
            }
        }

        if (entered && !exiting)
        {
            exitCounter += Time.deltaTime;
            if (exitCounter >= exitTimeMax)
            {
                ExitSite();
            }
        }
    }

    public void EnterSite()
    {
        gameObject.SetActive(true);
        entering = true;
        exiting = false;
    }
    
    public void TextChange(string x)
        {
        if(!String.IsNullOrEmpty(x))
        {
            text.text = x;
        }
        else
        {
            text.text = "TEXT IS NULL, PLEASE ASSIGN IT IN INSPECTOR";
        }
    }

    public void ExitSite()
    {
        exiting = true;
        exitCounter = 0;
    }
}
