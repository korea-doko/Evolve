using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectionManager : MonoBehaviour, IManager {

    public SelectionModel m_model;

    public static SelectionManager m_inst;
    public static SelectionManager GetInst()
    {
        return m_inst;
    }
    public SelectionManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<SelectionModel>("SelectionModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {

    }
    public void UpdateManager()
    {

    }

    
}
