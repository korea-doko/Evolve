using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputDir
{
    East,
    West,
    South,
    North
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

        m_screenTouchSensitivity = 100.0f;
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
        if (Vector3.Distance(m_buttonDownPos, Input.mousePosition) > m_screenTouchSensitivity)
            Debug.Log("aa");

    }
    void ButtonUp()
    {
        Debug.Log("moving distance : " + Vector3.Distance(m_buttonDownPos, Input.mousePosition).ToString());
        m_buttonDownPos = Vector3.zero;

        EventManager.GetInst().GetInputDir(InputDir.East);
        // 일단...

    }

  
}
