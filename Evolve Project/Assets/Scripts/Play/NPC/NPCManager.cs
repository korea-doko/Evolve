using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour ,IManager{

    public NPCModel m_model;
    public NPCView m_view;

    public static NPCManager m_inst;
    public static NPCManager GetInst()
    {
        return m_inst;
    }
    public NPCManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<NPCModel>("NPCModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {
        int numCard = CardManager.GetInst().m_model.m_cardList.Count;

        for (int i = 0; i < numCard; i++)
        {
            CardData cardData = CardManager.GetInst().m_model.m_cardList[i];
            NPCData npcData = m_model.GetNPCData(cardData.m_npcName);

            npcData.AddCardData(cardData);
        }
    }

    public void UpdateManager()
    {
    }



    public NPCData GetNPCData()
    {
        Debug.Log("여기에서 조건에 따라서 NPC를 골라야한다.");
        // 여기에는 복잡한 조건에 따라서 나오게 해야한다. 
        // 현재 플레이어의 상태에 따라서
        NPCName name = UnityEngine.Random.Range(0, 1) == 0 ? NPCName.God : NPCName.Player;
        

        return m_model.GetNPCData(name);
    }

    public CardData GetCardDataInNPCData(NPCData _data)
    {
        return _data.GetCardDataInPreferCondtion();
    }

}
