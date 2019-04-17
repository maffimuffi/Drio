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
    public float popupCounter;
    public float maxTime;
    public float popupSpeed;
    public float maxTransperency;
    public float transperencyChangeSpeed;
    private bool exiting;
    public TextMeshProUGUI text;
    public float maxSize;
    

    public float minSize;

    public float transperency;
    
    // Start is called before the first frame update
    void Start()
    {
        
        popupCounter = 0;
        backroundMat = GetComponent<RawImage>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        
        
        
        
        backroundMat.transform.localScale =
            new Vector3(backroundMat.transform.localScale.x -1 + minSize,
                backroundMat.transform.localScale.y -1 + minSize, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transperency = backroundMat.color.a;
        if (entering && !exiting)
        {
            popupCounter += Time.deltaTime;
            
                backroundMat.transform.localScale =
                    new Vector3(backroundMat.transform.localScale.x + popupCounter * popupSpeed,
                        backroundMat.transform.localScale.y + popupCounter * popupSpeed, 0);
            

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
            }
        } 
    }

    public void EnterSite()
    {
        entering = true;
        exiting = false;
    }
    
    public void TextChange(int x)
    {
        if (x == 0)
        {
            text.text = "Howdy, this is a test text!";
        } else if (x == 1)
        {
            text.text = "Hello world. Today is a fine day.";
        }
    }

    public void ExitSite()
    {
        
        exiting = true;
    }
}
