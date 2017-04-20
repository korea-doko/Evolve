using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectionManager : MonoBehaviour, IManager {

    public SelectionModel m_model;

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
        m_model = PlayManager.MakeObjectWithComponent<SelectionModel>("SelectionModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {

    }
    public void UpdateManager()
    {

    }
    public Selection[] GetSelectionsAbout()
    {
        // 일단 랜덤하게 2~4개를 보내준다.
        // 그러나 플레이어의 상태, 선택되어진 카드를 기반으로해서 여러가지 조건하에 결정된다.

        Selection[] selsAry = new Selection[4];

        int randomNum = UnityEngine.Random.Range(1,5);

        for (int i = 0; i < randomNum ; i++)
        {
            int randomSelID = UnityEngine.Random.Range(0, m_model.m_selectionList.Count);
            selsAry[i] = m_model.m_selectionList[randomSelID];
        }

        return selsAry;
    }

    
}
