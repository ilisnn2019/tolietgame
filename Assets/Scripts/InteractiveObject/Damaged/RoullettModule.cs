using UnityEngine;

public class RoullettModule
{
    //���� Ȯ��
    //���н�, 0.01%�� ����
    public float SuccessRate;

    //���н�, ������
    public float IncreaseRate;

    public RoullettModule()
    {
        SuccessRate = 0.0001f;
        IncreaseRate = 0.0001f;
    }

    public RoullettModule(float sr, float ir)
    {
        SuccessRate = sr;
        IncreaseRate = ir;
    }

    public bool TrySuccess()
    {
        if (Random.value < SuccessRate)
        {
            SuccessRate = 0.0001f;
            return true;
        }
        else
        {
            IncreaseSuccessRate();
            return false;
        }
    }

    private void IncreaseSuccessRate()
    {

        SuccessRate = Mathf.Min(SuccessRate + IncreaseRate, 1);
        Debug.Log($"{SuccessRate}");

    }
}