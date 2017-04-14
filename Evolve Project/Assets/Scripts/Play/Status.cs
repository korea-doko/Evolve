using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusParams
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
    
    public Status(int _damage, int _life, int _experience,int _hungry, int _magicPower)
    {
        m_paramAry = new int[5];
        m_paramAry[0] = _damage;
        m_paramAry[1] = _life;
        m_paramAry[2] = _experience;
        m_paramAry[3] = _hungry;
        m_paramAry[4] = _magicPower;
    }
    
}
