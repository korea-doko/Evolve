using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLogPanel : MonoBehaviour
{
    public Text m_text;

    public void Init()
    {
        
    }
    public void ChangeTextTo(string _log)
    {
        m_text.text = _log;
    }
}
