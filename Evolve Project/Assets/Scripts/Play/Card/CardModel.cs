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
            int[] selectionID = { Random.Range(-1, 9), Random.Range(-1, 9), Random.Range(-1, 9), Random.Range(-1, 9) };
            CardData data = new CardData(i.ToString(),i.ToString()+"Desc",selectionID);
            m_cardList.Add(data);
        }
    }
}
