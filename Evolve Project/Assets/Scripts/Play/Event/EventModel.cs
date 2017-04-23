using System.Collections;
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
    }
    public Selection GetSelectionElement(int _index)
    {
        if (_index >= m_selectedList.Count)
            return null;

        return m_selectedList[_index];
    }
    

}
