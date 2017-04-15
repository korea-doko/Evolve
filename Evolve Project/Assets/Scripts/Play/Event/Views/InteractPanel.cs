using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPanel : MonoBehaviour {

    public Animator m_ani;
    public Text m_text;
    public bool m_isIdle;
    public bool m_isEast;
    public bool m_isWest;
    public bool m_isSouth;
    public bool m_isNorth;

    public void Init()
    {
        m_isIdle = true;
        m_isEast = m_isWest = m_isSouth = m_isNorth = false;
        
        m_ani = this.GetComponent<Animator>();
    }
    public void ChangeTextTo(string _text)
    {
        m_text.text = _text;
    }
    public void AnimatorMoveTo(InputDir _dir)
    {
        m_isEast = m_isWest = m_isSouth = m_isNorth = false;
        m_isIdle = false;

        switch (_dir)
        {
            case InputDir.East:
                m_isEast = true;
                break;
            case InputDir.West:
                m_isWest = true;
                break;
            case InputDir.South:
                m_isSouth = true;
                break;
            case InputDir.North:
                m_isNorth = true;
                break;
            case InputDir.None:
                m_isIdle = true;
                break;
            default:
                break;
        }

        m_ani.SetBool("IsEast", m_isEast);
        m_ani.SetBool("IsWest", m_isWest);
        m_ani.SetBool("IsSouth", m_isSouth);
        m_ani.SetBool("IsNorth", m_isNorth);
        m_ani.SetBool("IsIdle", m_isIdle);
    }
}
