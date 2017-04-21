using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC0 : NPCData
{
    public override CardData GetCardDataInPreferCondtion()
    {

        int randomIndex = UnityEngine.Random.Range(0, m_cardList.Count - 1);

        Debug.Log(m_name.ToString() + " 선택된 번호 : " + randomIndex.ToString());
        return m_cardList[randomIndex];
    }
}

public class NPC1 : NPCData
{

    public override CardData GetCardDataInPreferCondtion()
    {
        
        int randomIndex = UnityEngine.Random.Range(0, m_cardList.Count - 1);

        Debug.Log(m_name.ToString() + " 선택된 번호 : " + randomIndex.ToString());

        return m_cardList[randomIndex];
    }
}