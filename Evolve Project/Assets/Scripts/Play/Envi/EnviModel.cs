using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeatherType
{
    Rain,
    Cloud,
    Sunny
}
public enum TimeType
{
   Day,
   Night
}
public enum LocationType
{
    Forest,
    River,
    Mountain,
    AncientTemple,
    Dungeon,
    Desert
}


public class EnviModel : MonoBehaviour {

    public WeatherType m_weather;
    public LocationType m_locaition;
    public TimeType m_time;
    public int m_turn;

    public void Init()
    {
        m_turn = 0;
        m_weather = WeatherType.Sunny;
        m_locaition = LocationType.Forest;
        m_time = TimeType.Day;
    }
}
