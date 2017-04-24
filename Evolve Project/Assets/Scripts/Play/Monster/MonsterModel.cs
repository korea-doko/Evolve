using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class MonsterModel : MonoBehaviour {

    public List<MonsterData> m_monsterList;
    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public void Init()
    {
        m_monsterList = new List<MonsterData>();

        ReadCardDataFromXml();

        for (int i = 0; i < m_fullDic.Count; i++)
            m_monsterList.Add(new MonsterData(m_fullDic[i]));

        m_fullDic = null;
    }
    void ReadCardDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAsset/Monster");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("Monster");


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
                    case "MonsterName":
                        partialDic.Add("MonsterName", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                    case "Damage":
                        partialDic.Add("Damage", content.InnerText);
                        break;
                    case "Life":
                        partialDic.Add("Life", content.InnerText);
                        break;
                    case "MagicPower":
                        partialDic.Add("MagicPower", content.InnerText);
                        break;
                    case "HungryPointPerTurn":
                        partialDic.Add("HungryPointPerTurn", content.InnerText);
                        break;
                    case "Virtue":
                        partialDic.Add("Virtue", content.InnerText);
                        break;
                    case "ExpForEvolution":
                        partialDic.Add("ExpForEvolution", content.InnerText);
                        break;
                    case "PassiveID":
                        partialDic.Add("PassiveID", content.InnerText);
                        break;

                }
            }
            m_fullDic.Add(partialDic);
        }

    }

   
}
