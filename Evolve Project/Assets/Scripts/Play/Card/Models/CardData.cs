using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CardData
{
    public string m_name;
    public Status m_deltaStatus;

    public CardData(string _name, Status _status)
    {
        m_name = _name;
        m_deltaStatus = _status;
    }

}
