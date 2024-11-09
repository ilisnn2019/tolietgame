using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public const float MAX_VITAL = 100;
    public const float MAX_STEMINA = 100;

    private float Vital;
    private float Stemina;
    private float Hunger;
    private float Thirsty;
    private float Mental;

    private void Start()
    {
        Vital = MAX_VITAL;
        Stemina = MAX_STEMINA;
    }

    /// <summary>
    /// ����Ż ��ġ�� �����մϴ�.<br></br>
    /// ���� �Ŀ� ��ü ����Ż ������ ��ȯ�մϴ�.
    /// </summary>
    /// <param name="vital">����� ��</param>
    /// <returns></returns>
    /// 
    public float ChangeVital(float vital)
    {
        Vital += vital;
        return Vital / MAX_VITAL;
    }

    public float ChangeStemina(float stemina)
    {
        Stemina += stemina;
        return Stemina / MAX_STEMINA;
    }

    public float ChangeHunger(float hunger)
    {
        Hunger += hunger;
        return Hunger;
    }

    public float ChangeThirsty(float thirsty)
    {
        Thirsty += thirsty;
        return Thirsty;
    }

    public float ChangeMental(float mental)
    {
        Mental += mental;
        return Mental;
    }
}
