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

    public NPCData GetPreferNPCData()
    {
        switch(EnviManager.GetInst().m_model.m_locaition)
        {
            case LocationType.Heaven:

                return GetNPCData(NPCName.GoblinVillage);
                
            case LocationType.GoblinVillage:

                return UnityEngine.Random.Range(0, 1) == 0 ? GetNPCData(NPCName.GoblinChildMinder) : GetNPCData(NPCName.GoblinWarrior);
                
            case LocationType.Forest:

                return GetNPCData(NPCName.Forest);
                
            case LocationType.DeepForest:

                return GetNPCData(NPCName.DeepForest);
                
            default:
                break;
        }

        Debug.Log("Error");

        return null;
        // 조건에 따라서 리턴해주면 된다.
        // 테스트 위해서.. // 캐릭터 타입의 NPC와 지형 타입의 NPC 두 종류가 있다.
        //NPCName name = NPCName.None;

        //while (name == NPCName.None || name == NPCName.God)
        //{
        //    int ran = UnityEngine.Random.Range(0, System.Enum.GetNames(typeof(NPCName)).Length - 1);

        //    name = (NPCName)ran;
        //}


        //return GetNPCData(name);
    }

    public NPCData GetNPCData(NPCName _name = NPCName.None)
    {
        return m_model.GetNPCData(_name);
    }
    public NPCData GetNPCDataHavingCardData(CardData _data)
    {
        if (_data == null)
            Debug.Log("Null input");

        return GetNPCData(_data.m_npcName);        
    }
    public CardData GetCardDataInNPCData(NPCData _data, CardName _cardName = CardName.None)
    {

        if (_cardName == CardName.None)
            return _data.GetCardDataInPreferCondtion();

        for(int i = 0; i < _data.m_cardList.Count;i++)
        {
            if (_data.m_cardList[i].m_cardName == _cardName)
                return _data.m_cardList[i];
        }


        Debug.Log("NPCData 안에 해당 CardID를 가진 CardData 없음");
        return null;       
    }

}
