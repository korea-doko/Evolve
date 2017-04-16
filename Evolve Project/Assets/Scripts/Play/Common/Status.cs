using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusType
{
    Damage,
    Life,
    Experience,
    Hungry,
    MagicPower
}
[System.Serializable]
public class Status
{
    public int[] m_paramAry;
    
    public Status()
    {
        m_paramAry = new int[5] { -1, -1, -1, -1, -1 };
    }
    public Status(Status _status)
    {
        m_paramAry = new int[5];
        for (int i = 0; i < 5; i++)
            m_paramAry[i] = _status.m_paramAry[i];
    }
    public Status(int _damage, int _life, int _experience,int _hungry, int _magicPower)
    {
        m_paramAry = new int[5];
        m_paramAry[0] = _damage;
        m_paramAry[1] = _life;
        m_paramAry[2] = _experience;
        m_paramAry[3] = _hungry;
        m_paramAry[4] = _magicPower;
    }
    
    public static Status operator+(Status _s1,Status _s2)
    {
        Status temp = new Status();

        for(int i = 0; i < 5; i ++)
            temp.m_paramAry[i] = _s1.m_paramAry[i] + _s2.m_paramAry[i];

        return temp;
    }
}
