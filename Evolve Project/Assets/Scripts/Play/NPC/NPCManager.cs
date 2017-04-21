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



    public NPCData GetNPCData(NPCName _name = NPCName.None)
    {
        // 지정된 NPCData라면, 그것을 리턴
        if (_name != NPCName.None)
            return m_model.GetNPCData(_name);

        
        // 지정된 NPCData가 아니라면, 조건에 따라서 NPC가져오게 하자.

        NPCName name = UnityEngine.Random.Range(0, 1) == 0 ? NPCName.God : NPCName.Player;

        return m_model.GetNPCData(name);
    }

    public CardData GetCardDataInNPCData(NPCData _data, int _cardID = -1)
    {
        if (_cardID == -1)
            return _data.GetCardDataInPreferCondtion();

        for(int i = 0; i < _data.m_cardList.Count;i++)
        {
            if (_data.m_cardList[i].m_givenID == _cardID)
                return _data.m_cardList[i];
        }


        Debug.Log("NPCData 안에 해당 CardID를 가진 CardData 없음");
        return null;       
    }

}
