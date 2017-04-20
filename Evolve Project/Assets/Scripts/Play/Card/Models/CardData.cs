using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;




[System.Serializable]
public class CardData
{
    public int m_givenID;
    public string m_name;
    public string m_desc;
    public NPCName m_npcName;
    public List<Selection> m_selList;
    
    public CardData(Dictionary<string,string> _data)
    {
        m_selList = new List<Selection>();

        m_givenID = int.Parse(_data["GivenID"]);
        m_name = "not";
        m_desc = _data["Desc"];
        m_npcName = (NPCName)int.Parse(_data["NPCID"]);
    } 
    public void AddSelection(Selection _sel)
    {
        m_selList.Add(_sel);
    }

}
