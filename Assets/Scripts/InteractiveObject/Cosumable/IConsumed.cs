using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어가 섭취 가능한 물체
/// </summary>
public interface IConsumed
{
    //ConsumeModule => 섭취 관련 클래스
    ConsumeModule IConsumed_M { get; }

    /// <summary>
    /// Function for adjusting the event in IConsumed interface
    /// </summary>
    abstract void ConsumedEvent();
}

public class ConsumeModule
{
    //마실 수 있는 양
    public float amount;

    public ConsumeModule()
    {
        amount = 1;
    }

    public bool TryConsume()
    {
        if(amount > 0)
        {
            amount -= 1;
            return true;
        }
        else
        {
            return false;
        }
    }
}
