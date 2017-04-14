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
        m_state = EventState.GetCard;

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
        m_model.ChangeSelectedCard(data);
        m_view.ChangeEventLogPanel(data.m_name);
        m_state = EventState.ReadyPlayer;
    }
    void ReadyPlayer()
    {

    }
    public void PressingDir(InputDir _dir)
    {
        // 누르고 있을 때 
        switch(_dir)
        {
            case InputDir.East:

                m_view.ChangeInteractPanel("E");
                break;
            case InputDir.West:

                m_view.ChangeInteractPanel("W");
                break;
            case InputDir.South:

                m_view.ChangeInteractPanel("S");
                break;
            case InputDir.North:

                m_view.ChangeInteractPanel("N");
                break;
            case InputDir.None:
            default:
                m_view.ChangeInteractPanel("");
                break;
        }

    }
    public void UpDir(InputDir _dir)
    {
        m_view.ChangeInteractPanel("");
        // 안보이게
        m_state = EventState.GetCard;

    }
}
