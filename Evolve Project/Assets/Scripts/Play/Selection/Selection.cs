using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Selection 
{
    public int m_givenID;
    public int m_cardID;
    public string m_desc;
    
    public Status m_deltaStatus;

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

        int deltaDamage = int.Parse(_data["DeltaDamage"]);
        int deltaLife = int.Parse(_data["DeltaLife"]);
        int deltaExp = int.Parse(_data["DeltaExp"]);
        int deltaHungry = int.Parse(_data["DeltaHungry"]);
        int deltaMagicPower = int.Parse(_data["DeltaMagicPower"]);

        m_deltaStatus = new Status(deltaDamage, deltaLife, deltaExp, deltaHungry, deltaMagicPower);
        
    }
 
}
