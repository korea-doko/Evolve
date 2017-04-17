using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviView : MonoBehaviour {

    public EnviPanel m_enviPanel;

    public void Init(EnviModel _model)
    {
        m_enviPanel = GameObject.Find("EnviPanel").GetComponent<EnviPanel>();

        ChangePanel(_model);
    }
    public void ChangePanel(EnviModel _model)
    {
        m_enviPanel.ChangePanel(_model);
    }
}
