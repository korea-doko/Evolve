using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectionManager : MonoBehaviour, IManager {

    public List<Selection> m_selectionList;

    public static SelectionManager m_inst;
    public static SelectionManager GetInst()
    {
        return m_inst;
    }
    public SelectionManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_selectionList = new List<Selection>();

        for(int i = 0; i < 10;i++)
        {
            Status stat = new Status(i, i, i, i, i);
            Selection sel = new Selection(i,i.ToString() + "Sel Name", i.ToString() + "Sel Desc",stat);
            m_selectionList.Add(sel);
        }
    }

    public void InitStart()
    {

    }
    public void UpdateManager()
    {

    }

    public Selection GetSelectionUsingID(int _selectionID)
    {
        if (_selectionID == -1)
            return null;

        return m_selectionList[_selectionID];
    }
    
}
