using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{

    public Text[] m_statusTextAry;

    public void Init(PlayerModel _model)
    {
        ChangePlayerStatus(_model);
    }

    public void ChangePlayerStatus(PlayerModel _model)
    {
        m_statusTextAry[(int)StatusType.Power].text = _model.GetStatus(StatusType.Power).ToString();
        m_statusTextAry[(int)StatusType.Life].text = _model.GetStatus(StatusType.Life).ToString();
        m_statusTextAry[(int)StatusType.Hungry].text = _model.GetStatus(StatusType.Hungry).ToString();
        m_statusTextAry[(int)StatusType.Virtue].text = _model.GetStatus(StatusType.Virtue).ToString();
    }
}