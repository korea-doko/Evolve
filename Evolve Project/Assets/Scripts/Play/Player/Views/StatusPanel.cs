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
        m_statusTextAry[(int)StatusType.Damage].text = _model.m_monData.m_damage.ToString();
        m_statusTextAry[(int)StatusType.Experience].text = _model.m_monData.m_currentExp.ToString();
        m_statusTextAry[(int)StatusType.Hungry].text = _model.m_monData.m_currentHungryPoint.ToString();
        m_statusTextAry[(int)StatusType.Life].text = _model.m_monData.m_life.ToString();
        m_statusTextAry[(int)StatusType.MagicPower].text = _model.m_monData.m_magicPower.ToString();
    }
}