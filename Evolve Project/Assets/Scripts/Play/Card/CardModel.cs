using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System;



public class CardModel : MonoBehaviour
{
    public List<CardData> m_cardList;
    public List<CardNameData> m_cardNameDataList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB



    public void Init()
    {
        LoadCardNameData();

        LoadCardData();
    }
    
    void LoadCardData()
    {
        m_cardList = new List<CardData>();

        ReadCardDataFromXml();

        for (int i = 0; i < m_fullDic.Count; i++)
        {
            string cardName = "CardData" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(cardName));

            CardData data = (CardData)obj;
            data.Init(m_fullDic[i]);

            m_cardList.Add(data);
        }

        
        for (int i = 0; i < m_fullDic.Count; i++)
            m_fullDic[i].Clear();

        m_fullDic.Clear();

        
    }
    void LoadCardNameData()
    {
        
        m_cardNameDataList = new List<CardNameData>();
        ReadCardNameDataFromXml();

        for (int i = 0; i < m_fullDic.Count;i++)
        {
            CardNameData nameData = new CardNameData(m_fullDic[i]);
            m_cardNameDataList.Add(nameData);
        }

        for (int i = 0; i < m_fullDic.Count; i++)
            m_fullDic[i].Clear();

        m_fullDic.Clear();
    }

    void ReadCardDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/CardTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("CardTable");

        
        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            Dictionary<string,string> partialDic = new Dictionary<string, string>(); // ItemName is TestItem;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        partialDic.Add("ID", content.InnerText);
                        break;
                    case "NPC":
                        partialDic.Add("NPC", content.InnerText);
                        break;
                    case "CardName":
                        partialDic.Add("CardName", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                    case "NextCardName":
                        partialDic.Add("NextCardName", content.InnerText);
                        break;
                    case "NextNPC":
                        partialDic.Add("NextNPC", content.InnerText);
                        break;
                    default:
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }

    }
    void ReadCardNameDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/CardNameTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("CardNameTable");


        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            Dictionary<string, string> partialDic = new Dictionary<string, string>(); // ItemName is TestItem;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        partialDic.Add("ID", content.InnerText);
                        break;
                    case "CardName":
                        partialDic.Add("CardName", content.InnerText);
                        break;
                    case "CardNameDesc":
                        partialDic.Add("CardNameDesc", content.InnerText);
                        break;
                    default:
                        break; ;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }



    public CardNameData GetCardNameData(int _id)
    {
        for(int i = 0; i < m_cardNameDataList.Count;i++)
        {
            if (m_cardNameDataList[i].m_id == _id)
                return m_cardNameDataList[i];
        }

        return m_cardNameDataList[0];
    }
    public CardNameData GetCardNameData(string _cardName)
    {
        for(int  i = 0; i < m_cardNameDataList.Count;i++)
        {
            if (m_cardNameDataList[i].m_cardName == _cardName)
                return m_cardNameDataList[i];
        }

        return m_cardNameDataList[0];
    }

    public CardData GetCardDataUsingCardName(CardName _name)
    {
        for(int i = 0; i < m_cardList.Count;i++)
        {
            if (m_cardList[i].m_cardName == _name)
                return m_cardList[i];
        }

        return m_cardList[0];
    }

    public CardData GetCardDataUsingIndex(int _index)
    {
        if (_index < 0 || _index > m_cardList.Count - 1)
            Debug.Log("Index Error");

        return m_cardList[_index];
    }
    public CardData GetCardDataUsingID(int _id)
    {
        for(int i = 0; i < m_cardList.Count ; i++)
        {
            if (_id == m_cardList[i].m_id)
                return m_cardList[i];
        }

        return null;
    }

}

