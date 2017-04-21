using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModel : MonoBehaviour {

    public CardData m_selectedCardData;
    public Selection[] m_selectedSelectionAry;
    public Selection m_selection;

    public NPCData m_selectedNPCData;

    public void Init()
    {
        m_selectedCardData = null;
        m_selection = null; 
        m_selectedSelectionAry = null;

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
    public void ChangeSelections(Selection[] _sels)
    {
        m_selectedSelectionAry = _sels;
    }
    public void SetSelection(Selection _sel)
    {
        m_selection = _sel;
    }
    public Selection GetSelectionElement(int _index)
    {
        return m_selectedSelectionAry[_index];
    }
    public void ClearSelections()
    {
        m_selectedCardData = null;
        m_selection = null;
        m_selectedSelectionAry = null;            
    }

}
