using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventView : MonoBehaviour {

    public EventLogPanel m_eventLogPanel;
    public InteractPanel m_interactPanel;

    public void Init(EventModel _model)
    {
        m_eventLogPanel = GameObject.Find("EventLogPanel").GetComponent<EventLogPanel>();
        m_eventLogPanel.Init();

        m_interactPanel = GameObject.Find("InteractPanel").GetComponent<InteractPanel>();
        m_interactPanel.Init();
    }

    public void ChangeEventLogPanel(string _text)
    {
        m_eventLogPanel.ChangeTextTo(_text);
    }
    public void ChangeInteractPanel(string _text)
    {
        m_interactPanel.ChangeTextTo(_text);
    }

}
