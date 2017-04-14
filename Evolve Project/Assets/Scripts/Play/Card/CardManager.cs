using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour, IManager {

    public CardModel m_model;
    public CardView m_view;

    public static CardManager m_inst;
    public static CardManager GetInst()
    {
        return m_inst;
    }
    public CardManager()
    {
        m_inst = this;
    }

    public void InitAwake()
    {
        m_model = PlayManager.MakeObjectWithComponent<CardModel>("CardModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {
        m_view = PlayManager.MakeObjectWithComponent<CardView>("CardView", this.gameObject);

        m_view.Init(m_model);
    }

    public CardData GetNextCard()
    {
        // 일단 랜덤으로..
        int randomIndex = UnityEngine.Random.Range(0, m_model.m_cardList.Count);

        CardData data = m_model.m_cardList[randomIndex]; 

        return data;
    }

    public void UpdateManager()
    {

    }

    



}
