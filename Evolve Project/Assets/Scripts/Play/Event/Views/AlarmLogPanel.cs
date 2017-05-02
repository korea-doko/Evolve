using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  나중에 이 View를 적절하게 옮겨야.. 일단 EventManager에 해당시켜주자.
 */
public class AlarmLogPanel : MonoBehaviour {

    public Animator m_ani;
    public Text m_text;
    public bool m_isInit;
    public bool m_isShow;


    public void Init()
    {
        m_ani = this.GetComponent<Animator>();
        m_isInit = m_ani.GetBool("IsInit");
        m_isShow = m_ani.GetBool("IsShow");                    
    }

    public void AlarmShow(string _alarmStr)
    {
        if (!m_isInit)
        {
            m_isInit = false;
            m_ani.SetBool("IsInit", m_isInit);
        }
        m_text.text = _alarmStr;

        m_isShow = true;
        m_ani.SetBool("IsShow", m_isShow);
    }
    public void Hide()
    {
        if (!m_isInit)
        {
            m_isInit = false;
            m_ani.SetBool("IsInit", m_isInit);
        }
        m_isShow = false;
        m_ani.SetBool("IsShow", m_isShow);
    }
}
