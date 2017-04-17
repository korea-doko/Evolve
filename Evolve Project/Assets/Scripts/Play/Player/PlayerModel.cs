using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public MonsterData m_monData;
    public List<Passive> m_passiveList;

    public bool m_isTest;

    public void Init()
    {
        m_isTest = true;

        m_passiveList = new List<Passive>();
    }
    public void InitMonData(MonsterData _monData)
    {
        m_monData = _monData;
    }
    public void ChangePlayerStatus(Status _status)
    {
        Debug.Log("변화줄 때, 여기서 스테이터스 변화량 패시브에 따라서 다르게 해야함....");

        Status tempStatus = _status;

        for (int i = 0; i < m_passiveList.Count; i++) 
            tempStatus = m_passiveList[i].ApplyToStatus(this,tempStatus);
        

        m_monData.ChangeStatus(tempStatus);
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
