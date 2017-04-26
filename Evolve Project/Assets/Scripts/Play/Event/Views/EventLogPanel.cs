using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLogPanel : MonoBehaviour
{
    public Text m_text;
    public Animator m_ani;
    public bool m_isInit;
    public bool m_isShow;

    public void Init()
    {
        m_ani = this.GetComponent<Animator>();
        m_isInit = m_ani.GetBool("IsInit");
        m_isShow = m_ani.GetBool("IsShow");                
    }
    public void ChangeTextTo(string _log)
    {
        m_text.text = _log;
    }
    public void Show()
    {
        if (m_isInit)
        {
            m_isInit = false;
            m_ani.SetBool("IsInit", m_isInit);
        }
        m_isShow = true;
        m_ani.SetBool("IsShow", m_isShow);
    }
    public void Hide()
    {
        if (m_isInit)
        {
            m_isInit = false;
            m_ani.SetBool("IsInit", m_isInit);
        }

        m_isShow = false;
        m_ani.SetBool("IsShow", m_isShow);
    }
}
