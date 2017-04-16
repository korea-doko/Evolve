using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public Status m_status;

    public void Init()
    {
        m_status = new Status(1, 1, 1, 1, 1);
    }
    public void ChangePlayerStatus(Status _status)
    {
        m_status = m_status + _status;
    }
}
