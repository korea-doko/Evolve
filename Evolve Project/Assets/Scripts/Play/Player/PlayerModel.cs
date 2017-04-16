using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public MonsterData m_monData;
    public List<Passive> m_passiveList;

    public void Init()
    {
        m_passiveList = new List<Passive>();
    }
    public void InitMonData(MonsterData _monData)
    {
        m_monData = _monData;
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
    public void CheckPassive()
    {
        for (int i = 0; i < m_passiveList.Count; i++)
            m_passiveList[i].Check(this);
    }

}
