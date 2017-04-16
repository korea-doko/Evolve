using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveManager : MonoBehaviour , IManager{

    public PassiveModel m_model;
    public PassiveView m_view;

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

}
