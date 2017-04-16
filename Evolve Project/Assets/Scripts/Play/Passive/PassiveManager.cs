using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveManager : MonoBehaviour , IManager{

    public PassiveModel m_model;
    public PassiveView m_view;

    public static PassiveManager m_inst;
    public static PassiveManager GetInst()
    {
        return m_inst;

    }
    public PassiveManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<PassiveModel>("PassiveModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {

    }

    public void UpdateManager()
    {

    }

    public Passive GetPassiveUsingID(int _id)
    {
        return m_model.m_passiveList[_id];
    }

}
