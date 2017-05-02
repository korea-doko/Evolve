using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnviPanelTextType
{
    Turn,
    Time,
    Weather,
    Location,
    Race
}
public class EnviPanel : MonoBehaviour {

    public List<Text> m_enviTextList;

    public void Init(EnviModel _model)
    {
        ChangePanel(_model);
    }

    public Text GetEnviTextTypeOf(EnviPanelTextType _type)
    {
        return m_enviTextList[(int)_type];
    }

    public void ChangePanel(EnviModel _model)
    {
        GetEnviTextTypeOf(EnviPanelTextType.Turn).text = _model.m_turn.ToString();
        GetEnviTextTypeOf(EnviPanelTextType.Time).text = _model.m_time.ToString();
        GetEnviTextTypeOf(EnviPanelTextType.Weather).text = _model.m_weather.ToString();
        GetEnviTextTypeOf(EnviPanelTextType.Location).text = _model.m_locaition.ToString();
       // GetEnviTextTypeOf(EnviPanelTextType.Race).text = "Not yet";
    }
}
