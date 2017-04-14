using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPanel : MonoBehaviour {

    public Text m_text;

    public void Init()
    {

    }
    public void ChangeTextTo(string _text)
    {
        m_text.text = _text;
    }
}
