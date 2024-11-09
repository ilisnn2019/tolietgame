using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ���� ������ ��ü
/// </summary>
public interface IConsumed
{
    //ConsumeModule => ���� ���� Ŭ����
    ConsumeModule IConsumed_M { get; }

    /// <summary>
    /// Function for adjusting the event in IConsumed interface
    /// </summary>
    abstract void ConsumedEvent();
}

public class ConsumeModule
{
    //���� �� �ִ� ��
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
