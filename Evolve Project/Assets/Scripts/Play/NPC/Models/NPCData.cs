using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCData
{
    public List<CardData> m_cardList;
    
    public NPCData()
    {
        m_cardList = new List<CardData>();
    }
    public void AddCardData(CardData _data)
    {
        m_cardList.Add(_data);
    }
}
