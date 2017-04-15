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

    public CardData(Dictionary<string,string> _data)
    {
        m_givenID = int.Parse(_data["GivenID"]);
        m_name = _data["CardName"];
        m_desc = _data["Desc"];
    } 
}
