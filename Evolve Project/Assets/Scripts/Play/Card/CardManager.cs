using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour, IManager {

    public CardModel m_model;
    public CardView m_view;

    public Selection[] m_returnSelectionAry;

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
        m_returnSelectionAry = new Selection[4];

        m_model = PlayManager.MakeObjectWithComponent<CardModel>("CardModel", this.gameObject);

        m_model.Init();
    }

    public void InitStart()
    {
        int numSelection = SelectionManager.GetInst().m_model.m_selectionList.Count;

        for (int i = 0; i < numSelection ; i++)
        {
            Selection sel = SelectionManager.GetInst().m_model.m_selectionList[i];

            CardData cardData = m_model.GetCardDataUsingID(sel.m_cardID);

            if( cardData == null)
            {
                Debug.Log("Finding Card ID = " + sel.m_cardID.ToString());
            }
            cardData.AddSelection(sel);
        }


        m_view = PlayManager.MakeObjectWithComponent<CardView>("CardView", this.gameObject);
        m_view.Init(m_model);
    }

   

    public void UpdateManager()
    {

    }

    public List<Selection> GetSelections(CardData _data)
    {
        return _data.GetPreferSelectionList();
    }
    

    public CardData GetCardDataUsingCardName(CardName _name)
    {
        return m_model.GetCardDataUsingCardName(_name);
    }
    

    public void AffectCard(CardData _data)
    {
        _data.Affect();      
    }
    public void CleanEffect(CardData _data)
    {
        _data.ClearEffect();
    }
    



}
