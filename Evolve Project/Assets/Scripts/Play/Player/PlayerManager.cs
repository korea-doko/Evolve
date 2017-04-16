using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IManager {

    public PlayerModel m_model;
    public PlayerView m_view;

    public static PlayerManager m_inst;
    public static PlayerManager GetInst()
    {
        return m_inst;
    }
    public PlayerManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<PlayerModel>("PlayerModel", this.gameObject);

        m_model.Init(); 

    }

    public void InitStart()
    {
        m_view = PlayManager.MakeObjectWithComponent<PlayerView>("PlayerView", this.gameObject);

        m_view.Init(m_model);
    }
    public void UpdateManager()
    {

    }
    public void ChangePlayerStatus(Selection _sel)
    {
        m_model.ChangePlayerStatus(_sel.m_deltaStatus);
        m_view.ChangePlayerStatus(m_model.m_status);
    }

}
