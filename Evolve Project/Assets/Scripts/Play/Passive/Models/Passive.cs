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
    public virtual void Check(PlayerModel _model)
    {
        // 계속해서 
    }
    public virtual Status ApplyToStatus(Status _status)
    {
        return null;
    }
}
