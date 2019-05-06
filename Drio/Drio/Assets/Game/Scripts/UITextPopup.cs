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

    public static bool talking = false;
    public bool isDialogueWaiting;
    
    private float dialogueMaxTime;
    public string TEXTSHOWING;
    private float popupCounter;
    private bool priorityText = false;
    public float exitCounter = 0;
    private float exitTimeMax = 5;
    private float dialogueCounter;
    private float maxTime = 1;
    private float popupSpeed = 0.1f;
    private float popupSpeed2 = 0.2f;
    private float maxTransperency;
    private float transperencyChangeSpeed;
    private bool exiting;
    private GameObject lastHitUiCollide;
    private TextMeshProUGUI text;
    private float maxSize = 1;
    public bool dialogueActive;
    private int lineCount = 0;
    private int maxLineCount;
    private Color32[] colors = new Color32[3]{Color.cyan,Color.green,Color.red};
    private Color32 activeColor;
    private int countz = 0;
    private float minSize = 0.5f;
    private bool changeColor;
    
    ///<see cref="0=None,1=Wind,2=Earth,3=Fire"/>
    private int whoIsTalking;

    private int whoLastSpoke;

    
    private string[] dialogueLines = new string[10];
    private List<string> lineList = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        activeColor = Color.white;
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
                ResetDialogue();
                
                entered = false;
                entering = false;
                exiting = false;
                popupCounter = 0;
                gameObject.SetActive(false);
            }
        }

        if (dialogueActive && !priorityText && !isDialogueWaiting)
        {
            
            TextChange(lineList[lineCount]);
            talking = true;
            dialogueCounter += Time.deltaTime;
            var asd = lineList[lineCount][0];
            if (asd == 'F' && lineList[lineCount][6] == ':')
            {
                whoIsTalking = 3;
                
            } else if (asd == 'G' && lineList[lineCount][4] == ':')
            {
                whoIsTalking = 1;
               
            } else if (asd == 'T' && lineList[lineCount][5] == ':')
            {
                whoIsTalking = 2;
                
            }
            else
            {
                whoIsTalking = 0;
            }
            

            

            if ((float)lineList[lineCount].Length / 9 <= 3f)
            {
                dialogueMaxTime = 3f;
            } else if ((float)lineList[lineCount].Length / 9 >= 15)
            {
                dialogueMaxTime = (float)lineList[lineCount].Length / 20;
            } else if ((float)lineList[lineCount].Length / 9 >= 7)
            {
                dialogueMaxTime = (float)lineList[lineCount].Length / 11;
            }
            else
            {
                dialogueMaxTime = (float)lineList[lineCount].Length / 9;
            }
            //Debug.Log("Line char length: " + lineList[lineCount].Length + " Max Time for next line: " + dialogueMaxTime);
            if (dialogueCounter >= dialogueMaxTime)
            {
                 
                lineCount++;
                dialogueCounter = 0;
                
                
                if (lineCount >= maxLineCount)
                {
                    
                    //pelaaja on lukenut kaikki popupit

                    if (lastHitUiCollide != null)
                    {
                        lastHitUiCollide.SetActive(false);
                    }

                    dialogueActive = false;
                    lineCount = 0;
                    ExitSite();
                }
            }
        }

        if (entered && !exiting && !dialogueActive)
        {
            exitCounter += Time.deltaTime;
            if (exitCounter >= exitTimeMax && isDialogueWaiting)
            {
                DialogueContinue();
            } else if (exitCounter >= exitTimeMax)
            {
                ExitSite();
            }
        }
        
    }

    public void ResetDialogue()
    {
        talking = false;
        popupCounter = 0;
        lineCount = 0;
        dialogueCounter = 0;
        whoLastSpoke = 0;
        whoIsTalking = 0;
        dialogueActive = false;
        lastHitUiCollide = null;
    }

    public void EnterSite()
    {
        gameObject.SetActive(true);
        entering = true;
        exiting = false;
    }

    public void DialoguePause()
    {
        isDialogueWaiting = true;
        dialogueActive = false;
        exitCounter = 0;
        whoLastSpoke = whoIsTalking;
        whoIsTalking = 0;

    }

    public void DialogueContinue()
    {
        exitCounter = 0;
        dialogueCounter = 0;
        priorityText = false;
        isDialogueWaiting = false;
        dialogueActive = true;
        whoIsTalking = whoLastSpoke;
        whoLastSpoke = 0;
    }
    public void Dialogue(int howManyLines, string[] lines, GameObject uiCollide)
    {
        
       
        if (lastHitUiCollide != null)
        {
            lastHitUiCollide.SetActive(false);
        }
        ResetDialogue();
        lastHitUiCollide = uiCollide;
        maxLineCount = howManyLines;
        lineList.Clear();
        countz = 0;
       
        
        foreach (var linea in lines)
        {
            
            lineList.Add(linea);
            

           
            countz++;
        }
        countz = 0;
        dialogueActive = true;
    }
    
    public void TextChange(string x)
        {
            if (!String.IsNullOrEmpty(x))
            {
                if (whoIsTalking != 0)
                {
                    if (whoIsTalking == 1)
                    {
                        text.text = "<#7becd8>" + x.Remove(4,x.Length-4) + "</color>" + x.Remove(0,4);
                    }  else if (whoIsTalking == 2)
                    {
                        text.text = "<#146f0b>"+ x.Remove(5,x.Length-5) + "</color>" + x.Remove(0,5);
                    } else if (whoIsTalking == 3)
                    {
                        text.text = "<#e33939>"+ x.Remove(6,x.Length-6) + "</color>" + x.Remove(0,6);
                    }
                }
                else
                {
                    text.text = x;
                }


            }
            else
        {
            text.text = "TEXT IS NULL, PLEASE ASSIGN IT IN INSPECTOR";
        }

            TEXTSHOWING = text.text;
        }

    public void PriorityText()
    {
        priorityText = true;
    }

    public void ExitSite()
    {
        
        priorityText = false;
        exiting = true;
        exitCounter = 0;
     
    }
}
