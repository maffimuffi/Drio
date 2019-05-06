using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActivePlayerText : MonoBehaviour
{

    
    private bool active;
    private float timer;
    private float maxTime = 2;
    public TextMeshProUGUI text;

    private RawImage backround;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        backround = GetComponentInParent<RawImage>();

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                timer = 0;
                active = false;
                backround.enabled = false;
                text.text = "";
            }
        }
        
    }

    public void ChangeActiveText()
    {
        timer = 0;
        active = true;
        backround.enabled = true;
        if (PlayerChanger.CharacterSelect == 1)
        {
            text.text = "<#7becd8>" + "Gust" + "</color>";
        } else if (PlayerChanger.CharacterSelect == 2)
        {
            text.text = "<#1FB312>" + "Terro" + "</color>";
        } else if (PlayerChanger.CharacterSelect == 3)
        {
            text.text ="<#e33939>" + "Fierre" + "</color>";
        }
    }
}
