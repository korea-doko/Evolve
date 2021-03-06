﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventState
{
    GetCard,            // 어떤 카드를 가져올 것인가?
    GetSelection,       // 어떤 선택지들을 가져오는가?
    CardEffect,         // 카드를 가져올 때, 먼저 발동되는 효과가 있다면 그것을 처리한다.
    ReadyPlayer,        // 플레이어의 선택을 기다린다.
    DoSelection,        // 선택된 것을 실행한다.
    CleanEffect,        // 카드를 가져올 때, 적용된 것이 초기화 될 필요가 있다면, 그것을 초기화 한다.
    NotifyOthers        // 다른 매니저에게 한번에 선택 싸이클이 돌았다는 것을 알려준다.
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
            case EventState.GetSelection:
                GetSelection();
                break;
            case EventState.CardEffect:
                CardEffect();
                break;
            case EventState.ReadyPlayer:
                ReadyPlayer();
                break;
            case EventState.DoSelection:
                DoSelection();
                break;
            case EventState.CleanEffect:
                CleanEffect();
                break;
            case EventState.NotifyOthers:
                NotifyOthers();
                break;    
            default:
                break;
        }
    }  

    void GetCard()
    {
        CardData data = CardManager.GetInst().GetCard();
        m_model.ChangeSelectedCard(data);
        // 카드가 선택됐음

      
        m_view.ChangeEventLogPanel(data.m_name);
        // 선택된 카드의 정보를 띄워준다.

        m_state = EventState.GetSelection;
    }
    void GetSelection()
    {
        Selection[] selAry = SelectionManager.GetInst().GetSelectionsAbout();
        m_model.ChangeSelections(selAry);
        // 해당 카드에 맞는 Selection을 가져와야 한다.

        m_state = EventState.CardEffect;
    }
    void CardEffect()
    {
        CardManager.GetInst().AffectCard(m_model.m_selectedCardData);
        
        m_state = EventState.ReadyPlayer;
    }
    void ReadyPlayer()
    {
        // 플레이어 인풋 대기 중
    }
    void DoSelection()
    {
        // 선택된 것을 실행한다.
        m_view.ChangeInteractPanel("", InputDir.None);

        PlayerManager.GetInst().ChangePlayerStatus(m_model.m_selection);

        m_state = EventState.CleanEffect;
    }

    void CleanEffect()
    {
        CardManager.GetInst().CleanEffect(m_model.m_selectedCardData);
        m_model.ClearSelections();




        m_state = EventState.NotifyOthers;
    }
    void NotifyOthers()
    {
        Debug.Log("나중에 여기 이름좀 바꿔야할듯");
        EnviManager.GetInst().Notified();


        m_state = EventState.GetCard;
    }


    public void PressingDir(InputDir _dir)
    {
        if (_dir == InputDir.None)
        {
            m_view.ChangeInteractPanel("", InputDir.None);
           return;
        }

        Selection sel =  m_model.m_selectedSelectionAry[(int)_dir];

        if (sel == null || sel.m_id == -1)
        {
            m_view.ChangeInteractPanel("", InputDir.None);
            return;
        }

        m_view.ChangeInteractPanel(sel.m_name, _dir);
        
    }
    public void UpDir(InputDir _dir)
    {
        Selection sel = m_model.m_selectedSelectionAry[(int)_dir];

        if (sel == null || sel.m_id == -1 )
            return;

        m_model.SetSelection(sel);
        m_state = EventState.DoSelection;        
    }
}
    