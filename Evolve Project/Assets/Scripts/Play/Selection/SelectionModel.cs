using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class SelectionModel : MonoBehaviour {

    public List<Selection> m_selectionList;
    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public void Init()
    {
        m_selectionList = new List<Selection>();

        ReadCardDataFromXml();

        for (int i = 0; i < m_fullDic.Count; i++)
            m_selectionList.Add(new Selection(m_fullDic[i]));

        m_fullDic = null;
    }

    void ReadCardDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAsset/Selection");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("Selection");


        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            Dictionary<string, string> partialDic = new Dictionary<string, string>(); // ItemName is TestItem;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "GivenID":
                        partialDic.Add("GivenID", content.InnerText);
                        break;
                    case "CardID":
                        partialDic.Add("CardID", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                    case "DeltaDamage":
                        partialDic.Add("DeltaDamage", content.InnerText);
                        break;
                    case "DeltaLife":
                        partialDic.Add("DeltaLife", content.InnerText);
                        break;
                    case "DeltaExp":
                        partialDic.Add("DeltaExp", content.InnerText);
                        break;
                    case "DeltaHungry":
                        partialDic.Add("DeltaHungry", content.InnerText);
                        break;
                    case "DeltaMagicPower":
                        partialDic.Add("DeltaMagicPower", content.InnerText);
                        break;
                    case "DeltaVirtue":
                        partialDic.Add("DeltaVirtue", content.InnerText);
                        break;
                    case "NextCardID":
                        partialDic.Add("NextCardID", content.InnerText);
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
}
