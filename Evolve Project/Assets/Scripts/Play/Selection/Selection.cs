using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Selection 
{
    public int m_id;
    public CardName m_parentCard;
    public string m_desc;
    public CardName m_nextCardName;
    public NPCName m_nextNPC;
    public Status m_deltaStatus;
	public int m_deltaTurn;

    public Selection()
    {
        m_id = -1;
        m_parentCard = CardName.None;
        m_desc = "no desc";
        m_nextCardName = CardName.None;
        m_nextNPC = NPCName.None;
        m_deltaStatus = new Status();
        m_deltaTurn = 0;
    }

    public Selection(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_parentCard = (CardName)int.Parse(_data["ParentCard"]);
        m_desc = _data["Desc"];

        int deltaPower = int.Parse(_data["DeltaPower"]);
        int deltaLife = int.Parse(_data["DeltaLife"]);
        int deltaExp = int.Parse(_data["DeltaExp"]);
        int deltaHungry = int.Parse(_data["DeltaHungry"]);
        int deltaVirtue = int.Parse(_data["DeltaVirtue"]);

        m_deltaStatus = new Status(deltaPower, deltaLife, deltaExp, deltaHungry,deltaVirtue);

        m_nextCardName = (CardName)int.Parse(_data["NextCardName"]);

        m_nextNPC = (NPCName)int.Parse(_data["NextNPC"]);
        m_deltaTurn = int.Parse(_data["DeltaTurn"]);
	}
 
}
