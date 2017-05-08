using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Selection 
{
    public int m_givenID;
    public int m_cardID;
    public string m_desc;
    public int m_nextCardID;
    public NPCName m_nextNPC;
    public Status m_deltaStatus;
	public int m_deltaTurn;

    public Selection()
    {
        m_givenID = -1;
        m_cardID = -1;
        m_desc = "no desc";
        m_deltaStatus = new Status();
    }

    public Selection(Dictionary<string,string> _data)
    {
        m_givenID = int.Parse(_data["GivenID"]);
        m_cardID = int.Parse(_data["CardID"]);
        m_desc = _data["Desc"];

        int deltaPower = int.Parse(_data["DeltaPower"]);
        int deltaLife = int.Parse(_data["DeltaLife"]);
        int deltaExp = int.Parse(_data["DeltaExp"]);
        int deltaHungry = int.Parse(_data["DeltaHungry"]);
        int deltaVirtue = int.Parse(_data["DeltaVirtue"]);

        m_deltaStatus = new Status(deltaPower, deltaLife, deltaExp, deltaHungry,deltaVirtue);

        m_nextCardID = int.Parse(_data["NextCardID"]);
        m_nextNPC = (NPCName)System.Enum.Parse(typeof(NPCName), _data["NextNPC"]);
		m_deltaTurn = int.Parse(_data["DeltaTurn"]);
	}
 
}
