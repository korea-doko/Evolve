using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NPCModel : MonoBehaviour
{
    public List<NPCData> m_npcDataList;

    public void Init()
    {
        m_npcDataList = new List<NPCData>();

        int numNPC = System.Enum.GetNames(typeof(NPCName)).Length - 1;
        // None이 -1로서 존재 따라서 하나 빼줘야 원하는 작동

        for (int i = 0; i < numNPC; i++)
        {
            string passiveName = "NPC" + ((NPCName)i).ToString();

            object obj = Activator.CreateInstance(Type.GetType(passiveName));
            NPCData npcData= (NPCData)obj;
            npcData.Init((NPCName)i);
            m_npcDataList.Add(npcData);
        }
    }

    public NPCData GetNPCData(NPCName _name)
    {
        return m_npcDataList[(int)_name];
    }
}
