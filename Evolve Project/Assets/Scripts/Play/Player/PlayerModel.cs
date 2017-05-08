using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public MonsterData m_monData;
    public List<Passive> m_passiveList;

    public Status m_curStatus;      // 현재 스테이터스
    /*
        m_curStatus.m_paramAry[(int)StatusType.Power] : 현재 공격력을 의미한다. 그대로 사용
        m_curStatus.m_paramAry[(int)StatusType.Experience] = 레벨 업 까지 필요한 총 경험치, 현재 경험치는 
                                                             m_curExp로 해야한다.
        m_curStatus.m_paramAry[(int)StatusType.Hungry] = 몬스터마다 배고픔이 늘어나는 것이 다른데 여기 포인트만큼 빠진다.
        m_curStatus.m_paramAry[(int)StatusType.Life] = 플레이어의 생명력 0이되면 죽음 그대로 사용;
        m_curStatus.m_paramAry[(int)StatusType.Virtue] =  플레이어의 미덕, 사실 빼는게 맞는데 그러면 바꿔야할꼐 많아서 일단..

     */

    public int m_curExp;            // 현재 경험치
    public int m_curHungryPoint;    // 현재 배고픔 정도

    public void Init()
    {
        m_curExp = 0;
        m_curHungryPoint = 0;

        m_curStatus = new Status();
        m_passiveList = new List<Passive>();
    }
    public void InitMonData(MonsterData _monData)
    {
        m_monData = _monData;

        m_curStatus.m_paramAry[(int)StatusType.Power] = _monData.m_power;
        m_curStatus.m_paramAry[(int)StatusType.Experience] = _monData.m_expForEvolution;
        m_curStatus.m_paramAry[(int)StatusType.Hungry] = _monData.m_hungryPointPerTurn;
        m_curStatus.m_paramAry[(int)StatusType.Life] = _monData.m_life;
        m_curStatus.m_paramAry[(int)StatusType.Virtue] = _monData.m_virtue;
    }
    public void ChangePlayerStatus(Status _status)
    {
        m_curStatus.m_paramAry[(int)StatusType.Power] += _status.GetStatusType(StatusType.Power);
        m_curStatus.m_paramAry[(int)StatusType.Life] += _status.GetStatusType(StatusType.Life);
        m_curStatus.m_paramAry[(int)StatusType.Virtue] += _status.GetStatusType(StatusType.Virtue);

        m_curHungryPoint += _status.GetStatusType(StatusType.Hungry);
        m_curExp += _status.GetStatusType(StatusType.Experience);
    }
    
    public void AttachPassive(Passive _passive)
    {
        _passive.Attach(this);
        m_passiveList.Add(_passive);
    }
    public void DetachPassive(Passive _passive)
    {
        _passive.Detach(this);
        m_passiveList.Remove(_passive);
    }
    public int GetStatus(StatusType _type)
    {
        Status tempStatus = m_curStatus;

        for (int i = 0; i < m_passiveList.Count; i++)
            tempStatus = m_passiveList[i].ApplyToStatus(this, EnviManager.GetInst().m_model, tempStatus);

        return tempStatus.GetStatusType(_type);
    }
    public float GetExpRatio()
    {
        float ratio = (float)m_curExp / (float)m_curStatus.GetStatusType(StatusType.Experience);
        return ratio;
    }
}
