using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCData
{
    public List<CardData> m_cardList;
    public Dictionary<int, List<Selection>> m_dic;
    
    public NPCData()
    {
        m_cardList = new List<CardData>();
        m_dic = new Dictionary<int, List<Selection>>();

    }
}
