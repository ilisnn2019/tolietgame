using UnityEngine;

public class RoullettModule
{
    const int TEN_THOUSAND = 1000;
    //성공 확률
    //실패시, 0.01%씩 증가
    public int SuccessRate;

    //실패시, 증가량
    public int IncreaseRate;

    public int durability;

    public RoullettModule()
    {
        SuccessRate = 1;
        IncreaseRate = 1;
        durability = 1;
    }

    public RoullettModule(int sr, int ir, int dr)
    {
        SuccessRate = sr;
        IncreaseRate = ir;
        durability = dr;
    }

    public bool TrySuccess()
    {
        if (Random.value < (float)SuccessRate / TEN_THOUSAND)
        {
            SuccessRate = 1;
            IncreaseRate *= 2;
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

        SuccessRate = Mathf.Max(SuccessRate + IncreaseRate, 1);
        Debug.Log($"{SuccessRate / TEN_THOUSAND}");

    }
}