using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public MonsterData m_monData;
    public List<Passive> m_passiveList;

    public Status m_curStatus;      // 현재 스테이터스
    
    //public int m_curDamage;         // 현재 공격력
    //public int m_curLife;           // 현재 생명력, 0 이면 게임 오버
    //public int m_curHungry;         // 현재 배고픔, 100이면 죽음
    //public int m_curMagicPower;     // 현재 마력
    //public int m_curVirtue;         // 현재 미덕, 플레이어의 선택에 따라서
    //public int m_curExp;            // 현재 경험치
    

    public void Init()
    {
        m_curStatus = new Status();
        m_passiveList = new List<Passive>();
    }
    public void InitMonData(MonsterData _monData)
    {
        m_monData = _monData;

        m_curStatus.m_paramAry[(int)StatusType.Power] = _monData.m_power;
        m_curStatus.m_paramAry[(int)StatusType.Experience] = _monData.m_expForEvolution;
        m_curStatus.m_paramAry[(int)StatusType.Hungry] = 100;
        m_curStatus.m_paramAry[(int)StatusType.Life] = _monData.m_life;
        m_curStatus.m_paramAry[(int)StatusType.Virtue] = _monData.m_virtue;
    }
    public void ChangePlayerStatus(Status _status)
    {
        m_curStatus += _status;
        //m_curDamage += _status.GetStatusType(StatusType.Damage);
        //m_curLife += _status.GetStatusType(StatusType.Life);
        //m_curHungry += _status.GetStatusType(StatusType.Hungry);
        //m_curMagicPower += _status.GetStatusType(StatusType.MagicPower);
        //m_curVirtue += _status.GetStatusType(StatusType.Virtue);
        //m_curExp += _status.GetStatusType(StatusType.Experience);
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
}
