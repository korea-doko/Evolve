using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventState
{
    CheckCondition,     // 조건을 검사, ex) 처음 시작인가? 지정된 카드가 있는가? 지정된 NPC가 있는가??
    GetNPC,             // 어떤 NPC 선택할 것인가?
    GetCardInNPC,       // NPC 안에 있는 적절한 카드를 가져온다.
    GetSelection,       // 어떤 선택지들을 가져오는가?
    CardEffect,         // 카드를 가져올 때, 먼저 발동되는 효과가 있다면 그것을 처리한다.
    ReadyPlayer,        // 플레이어의 선택을 기다린다.
    DoSelection,        // 선택된 것을 실행한다.
    CleanEffect,        // 카드를 가져올 때, 적용된 것이 초기화 될 필요가 있다면, 그것을 초기화 한다.
    NotifyOthers,       // 다른 매니저에게 한번에 선택 싸이클이 돌았다는 것을 알려준다.

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
        m_state = EventState.CheckCondition;

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
            case EventState.CheckCondition:
                CheckCondition();
                break;
            case EventState.GetNPC:
                GetNPC();
                break;
            case EventState.GetCardInNPC:
                GetCardInNPC();
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

    void CheckCondition()
    {

        if( m_model.m_nextCardID != -1)
        {
            // 선택된 카드가 있음.
            // 카드에 지정된 NPC가 있기 때문에 둘다 가져올 수 있음.
            CardData cardData = CardManager.GetInst().GetCardDataUsingID(m_model.m_nextCardID);
            NPCData npcData = NPCManager.GetInst().GetNPCDataHavingCardData(cardData);

            if (npcData == null)
                Debug.Log(" 해당 CardID를 가진 npc가 존재하지 않음");

            m_model.SetNPCData(npcData);
            // 해당 Card의 NPC를 찾아냈다.

            CardData cardDataInNPC = NPCManager.GetInst().GetCardDataInNPCData(npcData, m_model.m_nextCardID);
            m_model.ChangeSelectedCard(cardDataInNPC);

            m_view.ChangeEventLogPanel(cardDataInNPC.m_desc);

            m_state = EventState.GetSelection;

            return;
        }

        if( m_model.m_nextNPCName != NPCName.None )
        {
            // 카드는 지정안됐는데, 다음 NPC는 지정됐다.
            NPCData npcData = NPCManager.GetInst().GetNPCData(m_model.m_nextNPCName);
            m_model.SetNPCData(npcData);

            m_state = EventState.GetCardInNPC;
            return;
        }

        // NPC , 카드 둘다 지정이 안됐다
        m_state = EventState.GetNPC;            
    }
    void GetNPC()
    {
        // 현재 랜덤한 NPC가져오게 했음

        //NPCName name = UnityEngine.Random.Range(0, 1) == 0 ? NPCName.God : NPCName.Player;

        //NPCData npcData = NPCManager.GetInst().GetNPCData(name);
        NPCData npcData = NPCManager.GetInst().GetPreferNPCData();

        m_model.SetNPCData(npcData);
        
        m_state = EventState.GetCardInNPC;
    }
    void GetCardInNPC()
    {

        CardData data = NPCManager.GetInst().GetCardDataInNPCData(m_model.m_selectedNPCData);

        m_model.ChangeSelectedCard(data);
        // 카드가 선택됐음

        m_view.ChangeEventLogPanel(data.m_desc);
        // 선택된 카드의 정보를 띄워준다.

        m_state = EventState.GetSelection;
    }
    void GetSelection()
    {
        List<Selection> selList = CardManager.GetInst().GetSelections(m_model.m_selectedCardData);
        // GetSelection을 통해서 적절한 선택지를 가져와야하는데, 이때 플레이어의 정보와 
        // 어떤 지문인지 알아야 한다.

        m_model.ChangeSelections(selList);
        m_state = EventState.CardEffect;
    }
    void CardEffect()
    {
        // 전부 재정의 전까지...
        //CardManager.GetInst().AffectCard(m_model.m_selectedCardData);
        
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
        // 전부 재정의 전까지 다음 단계로 못나감 여기서 멈추니까..
        //CardManager.GetInst().CleanEffect(m_model.m_selectedCardData);

        m_state = EventState.NotifyOthers;
    }
    void NotifyOthers()
    {
        Debug.Log("나중에 여기 이름좀 바꿔야할듯");

        EnviManager.GetInst().Notified();
        m_state = EventState.CheckCondition;
    }
  


    public void PressingDir(InputDir _dir)
    {
        Debug.Log(_dir);

        if (_dir == InputDir.None)
        {
            m_view.ChangeInteractPanel("", InputDir.None);
           return;
        }
        
        Selection sel = m_model.GetSelectionElement((int)_dir);

        if (sel == null || sel.m_givenID == -1)
        {
            m_view.ChangeInteractPanel("", InputDir.None);
            return;
        }

        m_view.ChangeInteractPanel(sel.m_desc, _dir);
        
    }
    public void UpDir(InputDir _dir)
    {
        Debug.Log(_dir);
        Selection sel = m_model.GetSelectionElement((int)_dir);

        if (sel == null || sel.m_givenID == -1 )
            return;

        m_model.SetSelection(sel);
        m_state = EventState.DoSelection;        
    }
}
    