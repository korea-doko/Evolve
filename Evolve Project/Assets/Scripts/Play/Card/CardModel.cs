using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    public List<CardData> m_cardList;
    
    public void Init()
    {
        m_cardList = new List<CardData>();

        for(int i = 0;  i < 30 ;i++)
        {
            Status status = new Status(i, i, i, i, i);
            CardData data = new CardData(i.ToString(),status);
            m_cardList.Add(data);
        }
    }
}
