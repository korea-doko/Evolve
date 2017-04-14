using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventState
{
    GetCard,
    ReadyPlayer
}

public class EventManager : MonoBehaviour , IManager{

    public EventState m_state;

    public EventView m_view;
    public EventModel m_model;

    public static EventManager m_inst;
    public static EventManager GetInst()
    {
        return m_inst;
    }
    public EventManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_state = EventState.ReadyPlayer;

        m_model = PlayManager.MakeObjectWithComponent<EventModel>("EventModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {
        m_view = PlayManager.MakeObjectWithComponent<EventView>("EventView", this.gameObject);

        m_view.Init(m_model);
    }

    public void UpdateManager()
    {
        switch(m_state)
        {
            case EventState.GetCard:
                GetCard();
                break;
            case EventState.ReadyPlayer:
                ReadyPlayer();
                break;
            default:
                break;
        }
    }  

    void GetCard()
    {
        CardData data = CardManager.GetInst().GetNextCard();

        m_view.ChangeTextTo(data.m_name);

        m_state = EventState.ReadyPlayer;
    }
    void ReadyPlayer()
    {

    }

    public void GetInputDir(InputDir _dir)
    {
        m_state = EventState.GetCard;
    }
}
