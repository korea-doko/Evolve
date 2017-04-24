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
        m_statusTextAry[(int)StatusType.Damage].text = _model.GetStatus(StatusType.Damage).ToString();
        m_statusTextAry[(int)StatusType.Life].text = _model.GetStatus(StatusType.Life).ToString();
        m_statusTextAry[(int)StatusType.Hungry].text = _model.GetStatus(StatusType.Hungry).ToString();
        m_statusTextAry[(int)StatusType.MagicPower].text = _model.GetStatus(StatusType.MagicPower).ToString();
        m_statusTextAry[(int)StatusType.Virtue].text = _model.GetStatus(StatusType.Virtue).ToString();


    }
}