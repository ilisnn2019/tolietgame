using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSample : InteractiveObject
{

    protected override void AdjustEvents()
    {
        InteractiveEvent interactiveEvent = new("name", "description");
        interactiveEvent.eventContent += () =>
        {
            Debug.Log("test");
        };
        InteractiveEvents.Add(interactiveEvent);
    }
}
