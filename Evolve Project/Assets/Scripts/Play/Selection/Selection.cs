using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Selection 
{
    public int m_id;
    public string m_name;
    public string m_desc;
    public Status m_deltaStatus;

    public Selection(int _id,string _name, string _desc, Status _deltaStatus)
    {
        m_id = _id;
        m_name = _name;
        m_desc = _desc;
        m_deltaStatus = _deltaStatus;
    }


	
}
