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
        // 카드가 선택됐음

        Selection[] selAry = SelectionManager.GetInst().GetSelectionsAbout(data);
        m_model.ChangeSelections(selAry);
        // 해당 카드에 맞는 Selection을 가져와야 한다.

        m_view.ChangeEventLogPanel(data.m_name);
        // 선택된 카드의 정보를 띄워준다.

        m_state = EventState.ReadyPlayer;
    }
    void ReadyPlayer()
    {
        // 플레이어 인풋 대기 중
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
        m_view.ChangeInteractPanel("", InputDir.None);
        // 원래대로 돌아가게 만든다.

        if (sel == null || sel.m_id == -1 )
            return;
        
        PlayerManager.GetInst().ChangePlayerStatus(sel);

        m_model.ClearSelections();
        m_state = EventState.GetCard;        
    }
}
    