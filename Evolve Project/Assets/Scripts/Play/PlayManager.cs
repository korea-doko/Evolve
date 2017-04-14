using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ManagerType
{
    Input,
    Canvas,
    Card,
    Event,
    Player,
    Selection
}

public class PlayManager : MonoBehaviour
{
    public int m_numManager;
    public IManager[] m_managerAry;

    void Awake()
    {
        m_numManager = System.Enum.GetNames(typeof(ManagerType)).Length;
        m_managerAry = new IManager[m_numManager];

        for (int i = 0; i < m_numManager; i++)
        {
            string name = ((ManagerType)i).ToString() + "Manager";
            m_managerAry[i] = this.MakeManager(name, this.gameObject);
        }

        for (int i = 0; i < m_numManager; i++)
            m_managerAry[i].InitAwake();
    }
	void Start ()
    {
        for (int i = 0; i < m_numManager; i++)
            m_managerAry[i].InitStart();          
    }
    void Update()
    {
        for (int i = 0; i < m_numManager; i++)
            m_managerAry[i].UpdateManager();
    }

    IManager MakeManager(string _managerName,GameObject _parent = null)
    {
        GameObject temp = new GameObject(_managerName);

        if (_parent != null)
            temp.transform.SetParent(_parent.transform);

        Type comType = Type.GetType(_managerName);
        temp.AddComponent(comType);

        return temp.GetComponent<IManager>();

    }
    
    public static T MakeObjectWithComponent<T>(string _name, GameObject _parent =null) where T: Component
    {
        GameObject temp = new GameObject(_name);

        if (_parent != null)
            temp.transform.SetParent(_parent.transform);

        temp.name = _name;

        temp.AddComponent<T>();

        return temp.GetComponent<T>();
    }   
}

