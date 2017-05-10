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
    public List<Selection> m_selList;

    public int m_id;
    public CardName m_cardName;
    public NPCName m_npcName;
    public string m_desc;
    public NPCName m_nextNPC;
    public CardName m_nextCardName;

    
    public void Init(Dictionary<string,string> _data)
    {
        m_selList = new List<Selection>();

        m_id = int.Parse(_data["ID"]);
        m_cardName = (CardName)int.Parse(_data["CardName"]);
        m_npcName = (NPCName)int.Parse(_data["NPC"]);
        m_desc = _data["Desc"];
        m_nextNPC = (NPCName)int.Parse(_data["NextNPC"]);
        m_nextCardName = (CardName)int.Parse(_data["NextCardName"]);

                     
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
