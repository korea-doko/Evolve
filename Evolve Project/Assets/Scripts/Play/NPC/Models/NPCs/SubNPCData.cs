using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCName
{
    // 캐릭터 타입의 NPC와 지형 타입의 NPC 두 종류가 있다.
    None = 1,
	Player,
	God,
	// 캐릭터 타입

	GoblinChildMinder,
    GoblinWarrior,
	
    // 지형 타입

    GoblinVillage,
	Forest,
	DeepForest
}
public class NPCNone :NPCData
{
    public override void NPCEffect()
    {

    }
    public override CardData GetCardDataInPreferCondtion()
    {
        return base.GetCardDataInPreferCondtion();
    }
}
public class NPCPlayer : NPCData
{
    public override void NPCEffect()
    {
        base.NPCEffect();
    }
    public override CardData GetCardDataInPreferCondtion()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_cardList.Count - 1);

        Debug.Log(m_name.ToString() + " 선택된 번호 : " + randomIndex.ToString());

        return m_cardList[randomIndex];
     }
}
public class NPCGod : NPCData
{
    public override void NPCEffect()
    {

    }
    public override CardData GetCardDataInPreferCondtion()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_cardList.Count - 1);

        Debug.Log(m_name.ToString() + " 선택된 번호 : " + randomIndex.ToString());

        return m_cardList[randomIndex];
    }
}
public class NPCGoblinChildMinder :NPCData
{
    public override void NPCEffect()
    {
        base.NPCEffect();
    }
    public override CardData GetCardDataInPreferCondtion()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_cardList.Count - 1);

        Debug.Log(m_name.ToString() + " 선택된 번호 : " + randomIndex.ToString());

        return m_cardList[randomIndex];
    }
}
public class NPCGoblinWarrior : NPCData
{
    public override void NPCEffect()
    {
        base.NPCEffect();
    }
    public override CardData GetCardDataInPreferCondtion()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_cardList.Count - 1);

        Debug.Log(m_name.ToString() + " 선택된 번호 : " + randomIndex.ToString());

        return m_cardList[randomIndex];
    }
}
public class NPCGoblinKing : NPCData
{
	public override void NPCEffect()
	{
		base.NPCEffect();

	}
	public override CardData GetCardDataInPreferCondtion()
	{
		return base.GetCardDataInPreferCondtion();
	}
}
public class NPCGoblinVillage : NPCData
{
    public override void NPCEffect()
    {

    }
    public override CardData GetCardDataInPreferCondtion()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_cardList.Count - 1);

        Debug.Log(m_name.ToString() + " 선택된 번호 : " + randomIndex.ToString());

        return m_cardList[randomIndex];
    }
}
public class NPCForest : NPCData
{
	public override void NPCEffect()
	{
		base.NPCEffect();
	}
	public override CardData GetCardDataInPreferCondtion()
	{
		int randomIndex = UnityEngine.Random.Range(0, 2);

        if (randomIndex % 2 == 0)
            return m_cardList[0];
        else
            return m_cardList[m_cardList.Count - 1];


    }
}
public class NPCDeepForest : NPCData
{
	public override void NPCEffect()
	{
		base.NPCEffect();
	}
	public override CardData GetCardDataInPreferCondtion()
	{
		int randomIndex = UnityEngine.Random.Range(0, m_cardList.Count - 1);

		Debug.Log(m_name.ToString() + " 선택된 번호 : " + randomIndex.ToString());

		return m_cardList[randomIndex];
	}
}