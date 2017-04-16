using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour,IManager {

    public static MonsterManager m_inst;
    public static MonsterManager GetInst()
    {
        return m_inst;

    }
    public MonsterManager()
    {
        m_inst = this;
    }

    public MonsterModel m_model;
    public MonsterView m_view;

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<MonsterModel>("MonsterModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {

    }
    public void UpdateManager()
    {

    }
    
    public MonsterData DeepCopyMonsterDataUsingID(int _id)
    {
        MonsterData mon = m_model.m_monsterList[_id];
        MonsterData newData = new MonsterData(mon);
        return newData;
    }
}
