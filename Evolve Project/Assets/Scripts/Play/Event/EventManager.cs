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
        int selID =m_model.m_selectedCardData.GetSelectionID(_dir);

        Selection sel = SelectionManager.GetInst().GetSelectionUsingID(selID);

        if (sel != null)
            m_view.ChangeInteractPanel(sel.m_name,_dir);
        else
            m_view.ChangeInteractPanel("",_dir);
    
    }
    public void UpDir(InputDir _dir)
    {
        m_view.ChangeInteractPanel("",InputDir.None);
        // 원래대로 돌아가게 만든다.

        m_state = EventState.GetCard;

    }
}
