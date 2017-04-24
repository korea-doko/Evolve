using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusType
{
    Damage,
    Life,
    Hungry,
    MagicPower,
    Virtue,
    Experience
}
[System.Serializable]
public class Status
{
    public int[] m_paramAry;
    public int m_numStatusType;
    public Status()
    {
        m_numStatusType = System.Enum.GetNames(typeof(StatusType)).Length;
        m_paramAry = new int[m_numStatusType];

        for (int i = 0; i < m_numStatusType; i++)
            m_paramAry[i] = -1;

    }
    public Status(Status _status)
    {
        m_numStatusType = System.Enum.GetNames(typeof(StatusType)).Length;

        m_paramAry = new int[m_numStatusType];
        for (int i = 0; i < m_numStatusType; i++)
            m_paramAry[i] = _status.m_paramAry[i];
    }
    public Status(int _damage, int _life, int _experience,int _hungry, int _magicPower, int _virtue)
    {
        m_numStatusType = System.Enum.GetNames(typeof(StatusType)).Length;

        m_paramAry = new int[m_numStatusType];

        m_paramAry[(int)StatusType.Damage] = _damage;
        m_paramAry[(int)StatusType.Life] = _life;
        m_paramAry[(int)StatusType.Experience] = _experience;
        m_paramAry[(int)StatusType.Hungry] = _hungry;
        m_paramAry[(int)StatusType.MagicPower] = _magicPower;
        m_paramAry[(int)StatusType.Virtue] = _virtue;
    }
    public int GetStatusType(StatusType _type)
    {
        return m_paramAry[(int)_type];
    }
    public static Status operator +(Status _s1, Status _s2)
    {

        Status temp = new Status();
        int numStatType = System.Enum.GetNames(typeof(StatusType)).Length;

        for (int i = 0; i < numStatType; i++)
            temp.m_paramAry[i] = _s1.m_paramAry[i] + _s2.m_paramAry[i];

        return temp;
    }
}
