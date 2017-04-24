using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Passive
{
    public int m_id;

    public Passive()
    {

    }
    public virtual void Attach(PlayerModel _model)
    {
        // 붙을 때
    }
    public virtual void Detach(PlayerModel _model)
    {
        // 없어질 때
    } 
    public virtual Status ApplyToStatus(PlayerModel _playerModel,EnviModel _enviModel, Status _status)
    {
        // 특정 조건일 떄, 패시브 관련되서 가져오기
        // 사막일 때, 데미지 증가면, 
        return null;
    }
}
