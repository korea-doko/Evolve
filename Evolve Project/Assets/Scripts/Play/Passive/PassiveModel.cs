using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PassiveType
{
    Warrior,
    Aging,
    ManaUp
}
public class PassiveModel : MonoBehaviour {

    public List<Passive> m_passiveList;

    public void Init()
    {
        m_passiveList = new List<Passive>();

        int numPassiveType = System.Enum.GetNames(typeof(PassiveType)).Length;

        for (int i = 0; i < numPassiveType; i++)
        {
            string passiveName = "Passive" + i.ToString();

            object obj = Activator.CreateInstance(Type.GetType(passiveName));
            Passive passive = (Passive)obj;

            m_passiveList.Add(passive);
        }
    }


}
