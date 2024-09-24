using UnityEngine;

public class RoullettModule
{
    //성공 확률
    //실패시, 0.01%씩 증가
    public float SuccessRate;

    //실패시, 증가량
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