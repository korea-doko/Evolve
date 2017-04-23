﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModel : MonoBehaviour {

    public CardData m_selectedCardData;           // NPC안에 있는 카드 데이터 중에서 선택된 카드 데이터
    public List<Selection> m_selectedList;        // 카드 데이터 안에 있는 여러 선택지 중, 골라진 선택지 리스트

    public Selection m_selection;                 // 플레이어가 고른 선택지
    public NPCData m_selectedNPCData;             // 선택된 NPC Data

    public int m_nextCardID;                   // 다음에 와야하는 카드가 있습니까? -1 이라면 없음
    public NPCName m_nextNPCName;                // 다음에 와야하는 NPC가 있는가?

    public void Init()
    {
        m_selectedCardData = null;
        m_selectedList = null;

        m_selection = null;
        m_selectedNPCData = null;

        m_nextCardID = 1;
        m_nextNPCName = NPCName.God;
    }

    public void SetNPCData(NPCData _data)
    {
        m_selectedNPCData = _data;
    }

    public void ChangeSelectedCard(CardData _data)
    {
        m_nextCardID = _data.m_nextCardID;
        m_nextNPCName = _data.m_nextNPC;

        m_selectedCardData = _data;
    }
    public void ChangeSelections(List<Selection> _selList)
    {
        m_selectedList = _selList;
    }
    public void SetSelection(Selection _sel)
    {
        m_selection = _sel;
        
        /*
         *  카드가 정해지지 않았을 때만, NPC를 정확하게 구분해서 간다.
         *  카드가 정해지면 그 카드를 가진 NPC를 자동으로 찾기 때문이다.
         *  
         */
        if (m_nextCardID == -1)
            m_nextCardID = _sel.m_nextCardID;
        else
        {
            if (m_nextNPCName == NPCName.None)
                m_nextNPCName = _sel.m_nextNPC;
        }
    }
    public Selection GetSelectionElement(int _index)
    {
        if (_index >= m_selectedList.Count)
            return null;

        return m_selectedList[_index];
    }
    

}
