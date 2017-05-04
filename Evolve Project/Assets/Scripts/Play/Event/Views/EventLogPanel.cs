using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLogPanel : MonoBehaviour {

    public Text m_logText;

	public void Init()
    {
        m_logText.text = "init";
    }
    public void ChangeText(string _str)
    {
        m_logText.text = _str;
    }

}
