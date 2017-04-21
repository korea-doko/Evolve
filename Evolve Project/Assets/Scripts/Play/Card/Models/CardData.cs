using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;




[System.Serializable]
public class CardData
{

    public NPCName m_npcName;
    public int m_givenID;
    public string m_name;
    public string m_desc;
    public int m_nextCardID;
    public List<Selection> m_selList;

    
    public void Init(Dictionary<string,string> _data)
    {
        m_selList = new List<Selection>();

        m_npcName = (NPCName)int.Parse(_data["NPCID"]);
        m_givenID = int.Parse(_data["GivenID"]);
        m_name = _data["CardName"];
        m_desc = _data["Desc"];
        m_nextCardID = int.Parse(_data["NextCardID"]);
    }

    public void AddSelection(Selection _sel)
    {
        m_selList.Add(_sel);
    }

    public virtual List<Selection> GetPreferSelectionList()
    {
        return m_selList;
    }

}
