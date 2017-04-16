using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {

    public StatusPanel m_statusPanel;

	public void Init(PlayerModel _model)
    {
        m_statusPanel = GameObject.Find("StatusPanel").GetComponent<StatusPanel>();

        m_statusPanel.Init(_model);
    }
    public void ChangePlayerStatus(PlayerModel _model)
    {
        m_statusPanel.ChangePlayerStatus(_model);
    }
}
