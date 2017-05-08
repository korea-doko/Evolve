using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviManager : MonoBehaviour, IManager
{
    public EnviModel m_model;
    public EnviView m_view;

    public static EnviManager m_inst;
    public static EnviManager GetInst()
    {
        return m_inst;
    }
    public EnviManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<EnviModel>("EnviModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {
        m_view = PlayManager.MakeObjectWithComponent<EnviView>("EnviView", this.gameObject);

        m_view.Init(m_model);
    }

    public void UpdateManager()
    {
    }
    
    public void Notified()
    {
        Debug.Log(" 환경 매니저에서 즉당히 바꿔서..");

		m_model.ChangeTurn(EventManager.GetInst().m_model.m_selection.m_deltaTurn);


        m_view.ChangePanel(m_model);
    }
}
