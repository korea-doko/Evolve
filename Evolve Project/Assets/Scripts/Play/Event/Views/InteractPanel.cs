using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPanel : MonoBehaviour {

    public Text m_playerAnswerText;
    public Text m_npcNameText;

    public void Init()
    {

    }
    public void ChangeTextTo(string _text)
    {
        m_playerAnswerText.text = _text;
    }
    public void ChangeNPCTextTo(string _npcName)
    {
        m_npcNameText.text = _npcName;
    }
    

    public void ChangeImage()
    {
        Debug.Log("이미지바꾸기");
        
    }

  

  
}
