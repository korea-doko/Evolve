using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventView : MonoBehaviour {

    public EventLogPanel m_eventLogPanel;

    public void Init(EventModel _model)
    {
        m_eventLogPanel = GameObject.Find("EventLogPanel").GetComponent<EventLogPanel>();

        m_eventLogPanel.Init();
    }

    public void ChangeTextTo(string _text)
    {
        m_eventLogPanel.ChangeTextTo(_text);
    }

}
