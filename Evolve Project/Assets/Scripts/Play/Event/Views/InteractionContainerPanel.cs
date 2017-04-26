using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionContainerPanel : MonoBehaviour {

    public Animator m_ani;
    public bool m_isIn;
    public bool m_isEnd;

    public void Init()
    {
        m_ani = this.GetComponent<Animator>();
        m_isEnd = m_ani.GetBool("IsEnd");
        m_isIn = m_ani.GetBool("IsIn");                             
    }

    public bool IsAnimationEnd()
    {
        return m_isEnd;
    }

    public void PanelIn()
    {
        m_isEnd = false;
        m_isIn = true;
        m_ani.SetBool("IsIn", m_isIn);
    }
    public void PanelOut()
    {
        m_isEnd = false;
        m_isIn = false;
        m_ani.SetBool("IsIn", m_isIn);
    }
    public void AnimationEnd()
    {
        m_isEnd = true;
    }

}
