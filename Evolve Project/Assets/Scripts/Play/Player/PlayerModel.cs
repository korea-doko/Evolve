using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public MonsterData m_monData;
    public List<Passive> m_passiveList;

    
    public int m_curDamage;         // 현재 공격력
    public int m_curLife;           // 현재 생명력, 0 이면 게임 오버
    public int m_curHungry;         // 현재 배고픔, 100이면 죽음
    public int m_curMagicPower;     // 현재 마력
    public int m_curVirtue;         // 현재 미덕, 플레이어의 선택에 따라서
    public int m_curExp;            // 현재 경험치
    

    public void Init()
    {
        
        m_passiveList = new List<Passive>();
    }
    public void InitMonData(MonsterData _monData)
    {
        m_monData = _monData;
     
    }
    public void ChangePlayerStatus(Status _status)
    {
        m_curDamage += _status.GetStatusType(StatusType.Damage);
        m_curLife += _status.GetStatusType(StatusType.Life);
        m_curHungry += _status.GetStatusType(StatusType.Hungry);
        m_curMagicPower += _status.GetStatusType(StatusType.MagicPower);
        m_curVirtue += _status.GetStatusType(StatusType.Virtue);
        m_curExp += _status.GetStatusType(StatusType.Experience);


        //for (int i = 0; i < m_passiveList.Count; i++)
        //    m_changedStatus = m_passiveList[i].ApplyToStatus(this, m_changedStatus);
        
        /*
         * tempStatus를 통해서 플레이어 스테이터스가 변화하게 된다.
         * 그런데 실제로 바꿀 필요는 없고.. 연산을 통하면 된다. 
         */     
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

}
