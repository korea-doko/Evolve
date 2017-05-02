using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventView : MonoBehaviour {

    public EventLogPanel m_eventLogPanel;
    public InteractPanel m_interactPanel;
    public InteractionContainerPanel m_interactionContainerPanel;
 
    public void Init(EventModel _model)
    {
        m_eventLogPanel = GameObject.Find("EventLogPanel").GetComponent<EventLogPanel>();
        m_eventLogPanel.Init();

        m_interactPanel = GameObject.Find("InteractPanel").GetComponent<InteractPanel>();
        m_interactPanel.Init();

        m_interactionContainerPanel = GameObject.Find("InteractionContainerPanel").GetComponent<InteractionContainerPanel>();
        m_interactionContainerPanel.Init();      
    }

    public void ChangeEventLogPanel(string _text)
    {
        m_eventLogPanel.ChangeTextTo(_text);
        m_eventLogPanel.Show();
    }
    public void ChangeInteractPanel(string _text,InputDir _dir)
    {
        m_interactPanel.ChangeTextTo(_text);
        m_interactPanel.AnimatorMoveTo(_dir);
    }
    public void ChangeNPCNameTo(string _name)
    {
        m_interactPanel.ChangeNPCTextTo(_name);
        m_interactionContainerPanel.PanelIn();
    }
    public void ShowEventLogPanel()
    {
        m_eventLogPanel.Show();
    }
    public void HideEventLogPanel()
    {
        m_eventLogPanel.Hide();
        m_interactionContainerPanel.PanelOut();
    }

    public bool IsAnimationEnd()
    {
        if (!m_interactionContainerPanel.IsAnimationEnd())
            return false;

        return true;
    }
}
