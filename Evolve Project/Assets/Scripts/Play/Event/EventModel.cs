using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModel : MonoBehaviour {

    public CardData m_selectedCardData;
    public Selection[] m_selectedSelectionAry;

    public void Init()
    {
        m_selectedCardData = null;
        m_selectedSelectionAry = new Selection[4];

    }

    public void ChangeSelectedCard(CardData _data)
    {
        m_selectedCardData = _data;
    }
    public void ChangeSelections(Selection[] _sels)
    {
        m_selectedSelectionAry = _sels;
    }
    public void ClearSelections()
    {
        m_selectedSelectionAry = null;
    }

}
