using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventModel : MonoBehaviour {

    public CardData m_selectedCardData;

    public void Init()
    {
        m_selectedCardData = null;
    }

    public void ChangeSelectedCard(CardData _data)
    {
        m_selectedCardData = _data;
    }

}
