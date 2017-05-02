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

    public override Status ApplyToStatus(PlayerModel _playerModel, EnviModel _enviModel, Status _status)
    {

        Status temp = new Status(_status);
        temp.m_paramAry[(int)StatusType.Power] += 1;
        return temp;
    }
}
public class Passive1 : Passive
{
    public Passive1()
    {
        m_id = 1;
    }

    public override void Attach(PlayerModel _model)
    {
        _model.m_monData.m_damage /= 2;
        base.Attach(_model);
    }
    public override void Detach(PlayerModel _model)
    {
        _model.m_monData.m_damage *= 2;
        base.Detach(_model);
    }

    public override Status ApplyToStatus(PlayerModel _playerModel, EnviModel _enviModel, Status _status)
    {
        Status temp = new Status(_status);
        temp.m_paramAry[(int)StatusType.Hungry] += 2;
        return temp;
    }
}
public class Passive2 : Passive
{
    public Passive2()
    {
        m_id = 2;
    }
    public override void Attach(PlayerModel _model)
    {
        _model.m_monData.m_magicPower *= 2;
        base.Attach(_model);
    }
    public override void Detach(PlayerModel _model)
    {
        _model.m_monData.m_magicPower /= 2;
        base.Detach(_model);
    }
    public override Status ApplyToStatus(PlayerModel _playerModel, EnviModel _enviModel, Status _status)
    {
        Status temp = new Status(_status);
        temp.m_paramAry[(int)StatusType.Experience] += 10;
        return temp;
    }
}
