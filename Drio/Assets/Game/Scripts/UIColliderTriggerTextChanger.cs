using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColliderTriggerTextChanger : MonoBehaviour
{
    public int changerText;
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
        if (other.tag == "Player")
        {
            uiText.TextChange(changerText);
            uiText.EnterSite();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiText.ExitSite();
        }
    }
}
