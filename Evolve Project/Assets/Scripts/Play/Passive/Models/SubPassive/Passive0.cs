using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive0 : Passive
{
    
    public Passive0()
    {
        m_id = 0;
    }
    public override void Attach(PlayerModel _model)
    {
        _model.m_monData.m_damage *= 2;
        base.Attach(_model);
    }
    public override void Detach(PlayerModel _model)
    {
        _model.m_monData.m_damage /= 2;

        base.Detach(_model);
    }
    public override void Check(PlayerModel _model)
    {
        base.Check(_model);
    }
    public override Status ApplyToStatus(Status _status)
    {
        Status temp = new Status(_status);
        temp.m_paramAry[(int)StatusType.Damage] += 1;
        return temp;
    }
}
