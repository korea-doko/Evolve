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
    
    public void ChangeNPC(NPCData _data)
    {
        switch (_data.m_name)
        {
            case NPCName.None:
                break;
            case NPCName.Player:
                break;
            case NPCName.God:
                ChangeLocation(LocationType.Heaven);
                break;
            case NPCName.GoblinChildMinder:
            case NPCName.GoblinWarrior:
            case NPCName.GoblinVillage:
                ChangeLocation(LocationType.GoblinVillage);
                break;
            case NPCName.Forest:
                ChangeLocation(LocationType.Forest);
                break;
            case NPCName.DeepForest:
                ChangeLocation(LocationType.DeepForest);
                break;
        }
    }
    public void Notified()
    {
        m_model.m_turn += EventManager.GetInst().m_model.m_selection.m_deltaTurn;

        m_view.ChangePanel(m_model);
    }
    public void ChangeWeather(WeatherType _type)
    {
        m_model.m_weather = _type;

        m_view.ChangePanel(m_model);
    }
    public void ChangeLocation(LocationType _type)
    {
        m_model.m_locaition = _type;

        m_view.ChangePanel(m_model);
    }
    public void ChangeTime(TimeType _type)
    {
        m_model.m_time = _type;
        m_view.ChangePanel(m_model);
    }
}
