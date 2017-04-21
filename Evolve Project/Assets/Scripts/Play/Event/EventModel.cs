using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModel : MonoBehaviour {

    public CardData m_selectedCardData;
    public List<Selection> m_selectedList;

    public Selection m_selection;

    public NPCData m_selectedNPCData;

    public void Init()
    {
        m_selectedCardData = null;
        m_selection = null;
        m_selectedList = null;

        m_selectedNPCData = null;
    }

    public void SetNPCData(NPCData _data)
    {
        m_selectedNPCData = _data;
    }

    public void ChangeSelectedCard(CardData _data)
    {
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
    public void ClearSelections()
    {
        m_selectedCardData = null;
        m_selection = null;
        m_selectedList = null;            
    }

}
