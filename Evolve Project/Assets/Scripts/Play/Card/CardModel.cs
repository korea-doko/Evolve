﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;


public enum CardEffectType
{
    //Movement Type
    AncientTemple = 10200,

    // Engaing Enemy Type
    HuntingDog = 30000,
    GoblinSlayer = 30100,
    RankAWarrior = 30200,

    // Event Type
    ProtectionOfLight = 40000,
    BlessingOfDarkness = 40100,
    WarriorOfDesert = 40200
   
}

public class CardModel : MonoBehaviour
{
    public List<CardData> m_cardList;
    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public int m_listCount;

    public void Init()
    {
        m_cardList = new List<CardData>();

        ReadCardDataFromXml();    
        
        for(int i = 0; i < m_fullDic.Count;i++)
            m_cardList.Add(new CardData(m_fullDic[i]));

        m_listCount = m_cardList.Count;

        m_fullDic = null;
    }
    
    void ReadCardDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAsset/Card");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("Card");

        
        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            Dictionary<string,string> partialDic = new Dictionary<string, string>(); // ItemName is TestItem;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "NPCID":
                        partialDic.Add("NPCID", content.InnerText);
                        break;
                    case "GivenID":
                        partialDic.Add("GivenID", content.InnerText);
                        break;
                    case "CardName":
                        partialDic.Add("CardName", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                    case "NextCardID":
                        partialDic.Add("NextCardID", content.InnerText);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }

    }

    public CardData GetCardDataUsingIndex(int _index)
    {
        if (_index < 0 || _index > m_listCount - 1)
            Debug.Log("Index Error");

        return m_cardList[_index];
    }
    public CardData GetCardDataUsingID(int _id)
    {
        for(int i = 0; i < m_listCount; i++)
        {
            if (_id == m_cardList[i].m_givenID)
                return m_cardList[i];
        }

        return null;
    }

}

