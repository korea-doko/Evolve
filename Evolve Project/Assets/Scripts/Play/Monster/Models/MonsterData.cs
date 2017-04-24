using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterData
{
    public int m_id;
    public string m_name;
    public string m_desc;
    
    public int m_damage;
    public int m_life;
    public int m_virtue;
    public int m_magicPower;
    public int m_hungryPointPerTurn;
    public int m_expForEvolution;
    public int m_passiveID;

    

    public MonsterData()
    {
        m_id = -1;
        m_name = "no name";
        m_desc = "no desc";
        m_damage = -1;
        m_life = -1;
        m_magicPower = -1;
        m_hungryPointPerTurn = -1;
        m_expForEvolution = -1;
        m_passiveID = -1;
     }
    public MonsterData(MonsterData _data)
    {
        m_id = _data.m_id;
        m_name = _data.m_name;
        m_desc = _data.m_desc;
        m_damage = _data.m_damage;
        m_life = _data.m_life;
        m_magicPower = _data.m_magicPower;
        m_hungryPointPerTurn = _data.m_hungryPointPerTurn;
        m_expForEvolution = _data.m_expForEvolution;
        m_passiveID = _data.m_passiveID;
     }
    public MonsterData(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["GivenID"]);
        m_name = _data["MonsterName"];
        m_desc = _data["Desc"];
        m_damage = int.Parse(_data["Damage"]);
        m_life = int.Parse(_data["Life"]);
        m_virtue = int.Parse(_data["Virtue"]);
        m_magicPower = int.Parse(_data["MagicPower"]);
        m_hungryPointPerTurn = int.Parse(_data["HungryPointPerTurn"]);
        m_expForEvolution = int.Parse(_data["ExpForEvolution"]);
        m_passiveID = int.Parse(_data["PassiveID"]);        
    }

   
}
