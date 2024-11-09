using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSample : InteractiveObject, IDamaged, IConsumed
{
    private RoullettModule _Roullet_M;

    public RoullettModule IDamaged_Roullet_M => _Roullet_M;

    private ConsumeModule _Consume_M;

    public ConsumeModule IConsumed_M => _Consume_M;

    public override void Start()
    {
        base.Start();
        _Roullet_M = new();
        _Consume_M = new();
    }
    public override void InitEvent()
    {
        base.InitEvent();
        ShowAvailable += SampleEvent;
        ShowAvailable += DamagedEvent;
        ShowAvailable += ConsumedEvent;
    }
    public void DamagedEvent()
    {
        InteractiveEvent interactiveEvent = new("smash", "smash description");
        interactiveEvent.eventContent += () =>
        {
            if (IDamaged_Roullet_M.TrySuccess())
            {
                //성공
                Debug.Log("Success");
            }
            else
            {
                //실패
                Debug.Log($"Fail, current success rate : {IDamaged_Roullet_M.SuccessRate}");
            }
        };
        InteractiveEvents.Add(interactiveEvent);
    }

    void SampleEvent()
    {
        InteractiveEvent interactiveEvent = new("sample", "sample description");
        interactiveEvent.eventContent += () =>
        {
            Debug.Log("test");
        };
        InteractiveEvents.Add(interactiveEvent);
    }

    public void ConsumedEvent()
    {
        InteractiveEvent interactiveEvent = new("consume", "consume description");
        interactiveEvent.eventContent += () =>
        {
            if (IConsumed_M.TryConsume())
            {
                //성공
                Debug.Log("Success");
            }
            else
            {
                //실패
            }
        };
        InteractiveEvents.Add(interactiveEvent);
    }
}
