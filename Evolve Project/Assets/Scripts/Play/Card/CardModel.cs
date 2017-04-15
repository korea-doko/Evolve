using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class CardModel : MonoBehaviour
{
    public List<CardData> m_cardList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB
  
    public void Init()
    {
        m_cardList = new List<CardData>();

        ReadCardDataFromXml();    
        
        for(int i = 0; i < m_fullDic.Count;i++)
            m_cardList.Add(new CardData(m_fullDic[i]));

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
                    case "GivenID":
                        partialDic.Add("GivenID", content.InnerText);
                        break;
                    case "CardName":
                        partialDic.Add("CardName", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }

    }


}

