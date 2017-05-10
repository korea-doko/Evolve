using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardNameData
{
    public int m_id;
    public string m_cardName;
    public string m_cardNameDesc;

    public CardNameData(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_cardName = _data["CardName"];
        m_cardNameDesc = _data["CardNameDesc"];
    }
}
