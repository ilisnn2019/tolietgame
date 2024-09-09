using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : InteractiveObject
{ 
    public Transform doorNext;

    protected override void AdjustEvents()
    {
        InteractiveEvent interactiveEvent = new("Leave", "description");
        interactiveEvent.eventContent += () =>
        {
            Player.Instance.transform.position = doorNext.transform.position;
        };
        InteractiveEvents.Add(interactiveEvent);
    }

    
}
