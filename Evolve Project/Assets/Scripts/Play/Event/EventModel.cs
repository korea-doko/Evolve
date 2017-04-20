using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModel : MonoBehaviour {

    public CardData m_selectedCardData;
    public Selection[] m_selectedSelectionAry;
    public Selection m_selection;

    public void Init()
    {
        m_selectedCardData = null;
        m_selection = null; 
        m_selectedSelectionAry = null;

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
    public void ClearSelections()
    {
        m_selectedCardData = null;
        m_selection = null;
        m_selectedSelectionAry = null;            
    }

}
