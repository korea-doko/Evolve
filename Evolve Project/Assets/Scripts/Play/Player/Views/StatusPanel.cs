using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{

    public Text[] m_statusTextAry;

    public void Init(Status _status)
    {
        ChangePlayerStatus(_status);
    }

    public void ChangePlayerStatus(Status _status)
    {
        for (int i = 0; i < 5; i++)
            m_statusTextAry[i].text = _status.m_paramAry[i].ToString();

    }
}