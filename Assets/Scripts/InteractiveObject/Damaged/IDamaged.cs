using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �÷��̾ ���ظ� �� �� �ִ� ��ü
/// </summary>

public interface IDamaged
{
    //RoulletModule => Ȯ�� ���� Ŭ����
    RoullettModule IDamaged_Roullet_M { get; }

    /// <summary>
    /// Function for adjusting the event in IDamaged interface
    /// </summary>
    abstract void DamagedEvent();


}


