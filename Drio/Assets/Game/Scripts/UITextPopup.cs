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
    private TextMeshProUGUI text;
    private float maxSize = 1;
    private bool dialogueActive;
    private int lineCount = 0;
    private int maxLineCount;
    private Color32[] colors = new Color32[3]{Color.cyan,Color.green,Color.red};
    private Color32 activeColor;
    private int countz = 0;
    private float minSize = 0.5f;
    private bool changeColor;

    
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

        if (dialogueActive && !priorityText)
        {
            
            TextChange(lineList[lineCount]); 
            
            dialogueCounter += Time.deltaTime;
            

            if ((float)lineList[lineCount].Length / 9 <= 2.5f)
            {
                dialogueMaxTime = 2.5f;
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
            Debug.Log("Linelist length: " + lineList[lineCount].Length + " Max Time: " + dialogueMaxTime);
            if (dialogueCounter >= dialogueMaxTime)
            {
                 
                lineCount++;
                dialogueCounter = 0;
                
                
                if (lineCount >= maxLineCount)
                {
                    
                    //pelaaja on lukenut kaikki popupit
                    
                    dialogueActive = false;
                    lineCount = 0;
                    ExitSite();
                }
            }
        }

        if (entered && !exiting && !dialogueActive)
        {
            exitCounter += Time.deltaTime;
            if (exitCounter >= exitTimeMax)
            {
                ExitSite();
            }
        }
        
    }

    public void ResetDialogue()
    {
        popupCounter = 0;
        lineCount = 0;
        dialogueCounter = 0;
        text.color = Color.cyan;
        dialogueActive = false;
    }

    public void EnterSite()
    {
        gameObject.SetActive(true);
        entering = true;
        exiting = false;
    }

    public void Dialogue(int howManyLines, string[] lines)
    {

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
                
                    text.text = x;

                   
                
            }
            else
        {
            text.text = "TEXT IS NULL, PLEASE ASSIGN IT IN INSPECTOR";
        }
/*
            
                TMP_WordInfo info = text.textInfo.wordInfo[0];
                if (info.GetWord() == "Gust")
                {
                    activeColor = colors[0];
                    changeColor = true;
                }
                else if (info.GetWord() == "Terra")
                {
                    activeColor = colors[1];
                    changeColor = true;
                }
                else if (info.GetWord() == "Fierre")
                {
                    activeColor = colors[2];
                    changeColor = true;
                }
                else
                {
                    activeColor = Color.white;
                    changeColor = true;

                }

                if (changeColor)
                {
                    for (int i = 0; i < info.characterCount + 1; ++i)
                    {
                        int charIndex = info.firstCharacterIndex + i;
                        int meshIndex = text.textInfo.characterInfo[charIndex].materialReferenceIndex;
                        int vertexIndex = text.textInfo.characterInfo[charIndex].vertexIndex;
                        Debug.Log(info.GetWord());


                        Color32[] vertexColors = text.textInfo.meshInfo[meshIndex].colors32;
                        vertexColors[vertexIndex + 0] = activeColor;
                        vertexColors[vertexIndex + 1] = activeColor;
                        vertexColors[vertexIndex + 2] = activeColor;
                        vertexColors[vertexIndex + 3] = activeColor;
                    }

                    for (int i = info.characterCount + 1; i < text.text.Length; ++i)
                    {

                        activeColor = Color.white;
                            int charIndex = info.firstCharacterIndex + i;
                            int meshIndex = text.textInfo.characterInfo[charIndex].materialReferenceIndex;
                            int vertexIndex = text.textInfo.characterInfo[charIndex].vertexIndex;
                            


                            Color32[] vertexColors = text.textInfo.meshInfo[meshIndex].colors32;
                            vertexColors[vertexIndex + 0] = activeColor;
                            vertexColors[vertexIndex + 1] = activeColor;
                            vertexColors[vertexIndex + 2] = activeColor;
                            vertexColors[vertexIndex + 3] = activeColor;
                    }
                }

                text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            */

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
        /*
        if (text.textInfo.wordInfo[0].GetWord() != null)
        {
            TMP_WordInfo info = text.textInfo.wordInfo[0];
            activeColor = Color.white;
            for (int i = 0; i < text.text.Length; ++i)
            {
                int charIndex = info.firstCharacterIndex + i;
                int meshIndex = text.textInfo.characterInfo[charIndex].materialReferenceIndex;
                int vertexIndex = text.textInfo.characterInfo[charIndex].vertexIndex;
                Color32[] vertexColors = text.textInfo.meshInfo[meshIndex].colors32;
                vertexColors[vertexIndex + 0] = activeColor;
                vertexColors[vertexIndex + 1] = activeColor;
                vertexColors[vertexIndex + 2] = activeColor;
                vertexColors[vertexIndex + 3] = activeColor;

                text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            }
        }
        */
    }
}
