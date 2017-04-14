using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputDir
{
    East,
    West,
    South,
    North,
    None
}
public class InputManager : MonoBehaviour, IManager
{
    public Vector3 m_buttonDownPos;
    public float m_screenTouchSensitivity;  // 얼마나 이동해야 실제 입출력으로 처리할 것인가

    public static InputManager m_inst;
    public static InputManager GetInst()
    {
        return m_inst;
    }
    public InputManager()
    {
        m_inst = this;
    }
    
    public void InitAwake()
    {
        m_buttonDownPos = Vector3.zero;

        m_screenTouchSensitivity = 300.0f;
    }
    public void InitStart()
    {

    }
    public void UpdateManager()
    {
        if (Input.GetMouseButtonDown(0))
            ButtonDown();

        if (Input.GetMouseButton(0))
            ButtonPressing();

        if (Input.GetMouseButtonUp(0))
            ButtonUp();
    }

    void ButtonDown()
    {
        m_buttonDownPos = Input.mousePosition;
    }
    void ButtonPressing()
    {
        EventManager.GetInst().PressingDir(GetDir(m_buttonDownPos, Input.mousePosition));      
    }
    void ButtonUp()
    {
        m_buttonDownPos = Vector3.zero;

        EventManager.GetInst().UpDir(GetDir(m_buttonDownPos, Input.mousePosition)); 
    }

    public InputDir GetDir(Vector3 _startPos, Vector3 _endPos)
    {
        float disX = Mathf.Abs( _endPos.x - _startPos.x);
        float disY = Mathf.Abs( _endPos.y - _startPos.y);
        
        if (disX < m_screenTouchSensitivity && disY < m_screenTouchSensitivity)
            return InputDir.None;

        if( disX > disY)
        {
            if (_endPos.x > _startPos.x)
                return InputDir.East;
            else
                return InputDir.West;    
        }
        else
        {
            if (_endPos.y > _startPos.y)
                return InputDir.North;
            else
                return InputDir.South;
        }
    }

  
}
