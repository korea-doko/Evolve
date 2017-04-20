using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour ,IManager{

    public NPCModel m_model;
    public NPCView m_view;

    public static NPCManager m_inst;
    public static NPCManager GetInst()
    {
        return m_inst;
    }
    public NPCManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<NPCModel>("NPCModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {

    }

    public void UpdateManager()
    {
    }    
}
