using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CardData
{
    public string m_name;
    public string m_desc;
    public int[] m_selectionID;

    public CardData(string _name,string _desc,int[] _selectionID)
    {
        m_selectionID = new int[4];

        m_name = _name;
        m_desc = _desc;

        m_selectionID = _selectionID;
    }
    public int GetSelectionID(InputDir _dir)
    {
        if (_dir == InputDir.None)
            return -1;

        return m_selectionID[(int)_dir];
    }

}
