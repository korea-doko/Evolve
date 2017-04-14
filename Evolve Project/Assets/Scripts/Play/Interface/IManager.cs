using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    void InitAwake();       // 자기 내부에서 만 사용하는 초기화일 때,
    void InitStart();       // 외부 클래스 사용 시
    void UpdateManager();
}