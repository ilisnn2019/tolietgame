using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 플레이어가 피해를 줄 수 있는 물체
/// </summary>

public interface IDamaged
{
    //RoulletModule => 확률 관련 클래스
    RoullettModule IDamaged_Roullet_M { get; }

    /// <summary>
    /// Function for adjusting the event in IDamaged interface
    /// </summary>
    abstract void DamagedEvent();


}


