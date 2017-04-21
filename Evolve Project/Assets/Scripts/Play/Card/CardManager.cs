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

            cardData.AddSelection(sel);
        }


        m_view = PlayManager.MakeObjectWithComponent<CardView>("CardView", this.gameObject);
        m_view.Init(m_model);
    }

   

    public void UpdateManager()
    {

    }

    public Selection[] GetSelections(CardData _data)
    {
       

        int count = _data.m_selList.Count;

        if (count == 0)
            return null;

        int randNum = UnityEngine.Random.Range(0, 4);

        for(int i = 0; i < randNum;i++)
        {
            int randIndex = UnityEngine.Random.Range(0, count - 1);

            if (_data.m_selList[i] == null)
                break;

            m_returnSelectionAry[i] = _data.m_selList[i];
        }

        return m_returnSelectionAry;
    }

    public void AffectCard(CardData _data)
    {
        CardEffectType type = (CardEffectType)_data.m_givenID;

        switch (type)
        {
            case CardEffectType.AncientTemple:
                Debug.Log("모험가 타이틀 있으면 생명력 +1");
                break;
            case CardEffectType.HuntingDog:

                Debug.Log("스켈레톤 타입일 경우 데미지 -1");
                break;
            case CardEffectType.GoblinSlayer:
                Debug.Log("코볼트일 때, 시작 시 생명력 -1 모든 선택지에서 부정적효과 -1");
                break;
            case CardEffectType.RankAWarrior:
                Debug.Log("A랭크 이하 몬스터일 경우, 부정적 효과 -1, B랭크 이하일 경우 -2");
                break;
            case CardEffectType.ProtectionOfLight:

                Debug.Log("패시브 :빛의수호");
                break;
            case CardEffectType.BlessingOfDarkness:

                Debug.Log("패시브 :어둠의전사");
                break;
            case CardEffectType.WarriorOfDesert:

                Debug.Log("패시브 :사막의전사");
                break;
            default:
                break;
        }
    }
    public void CleanEffect(CardData _data)
    {
        CardEffectType type = (CardEffectType)_data.m_givenID;

        switch (type)
        {
            case CardEffectType.AncientTemple:
                Debug.Log("정리");
                break;
            case CardEffectType.HuntingDog:
                Debug.Log("정리");
                break;
            case CardEffectType.GoblinSlayer:
                Debug.Log("정리");
                break;
            case CardEffectType.RankAWarrior:
                Debug.Log("정리"); break;
            case CardEffectType.ProtectionOfLight:

                Debug.Log("정리"); break;
            case CardEffectType.BlessingOfDarkness:

                Debug.Log("정리"); break;
            case CardEffectType.WarriorOfDesert:

                Debug.Log("정리"); break;
            default:
                break;
        }
    }
    



}
