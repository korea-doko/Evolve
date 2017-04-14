using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour,IManager
{
    public CanvasModel m_model;
    public CanvasView m_view;

    public static CanvasManager m_inst;
    public static CanvasManager GetInst()
    {
        return m_inst;
    }
    public CanvasManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<CanvasModel>("CanvasModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {

    }

    public void UpdateManager()
    {

    }
}
