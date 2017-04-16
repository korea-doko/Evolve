using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {

    public StatusPanel m_statusPanel;

	public void Init(PlayerModel _model)
    {
        m_statusPanel = GameObject.Find("StatusPanel").GetComponent<StatusPanel>();

        //m_statusPanel.Init(_model.m_status);
    }
    public void ChangePlayerStatus(Status _status)
    {
        m_statusPanel.ChangePlayerStatus(_status);
    }
}
