using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCData
{
    public NPCName m_name;
    public List<CardData> m_cardList;
    
    public NPCData()
    {
        m_cardList = new List<CardData>();
    }
    public void Init(NPCName _name)
    {
        m_name = _name;
    }
    public void AddCardData(CardData _data)
    {
        m_cardList.Add(_data);
    }

    public virtual void NPCEffect()
    {
        Debug.Log("Effect " + m_name.ToString());
    }

    public virtual CardData GetCardDataInPreferCondtion()
    {
        return null;
    }
}
