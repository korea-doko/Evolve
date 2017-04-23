using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public interface ICardData
{
    List<Selection> GetPreferSelectionList();
    void Affect();
    void ClearEffect();
}

[System.Serializable]
public class CardData : ICardData
{

    public NPCName m_npcName;
    public int m_givenID;
    public string m_name;
    public string m_desc;
    public int m_nextCardID;
    public List<Selection> m_selList;
    public NPCName m_nextNPC;
    
    
    public void Init(Dictionary<string,string> _data)
    {
        m_selList = new List<Selection>();

        m_npcName = (NPCName)Enum.Parse(typeof(NPCName), _data["NPC"]);
        m_givenID = int.Parse(_data["GivenID"]);
        m_name = _data["CardName"];
        m_desc = _data["Desc"];
        m_nextCardID = int.Parse(_data["NextCardID"]);

        m_nextNPC = (NPCName)Enum.Parse(typeof(NPCName), _data["NextNPC"]);

    }
    public void AddSelection(Selection _sel)
    {
        m_selList.Add(_sel);
    }

    public virtual List<Selection> GetPreferSelectionList()
    {
        return m_selList;
    }

    public virtual void Affect()
    {
        throw new NotImplementedException();
    }

    public virtual void ClearEffect()
    {
        throw new NotImplementedException();
    }
}
