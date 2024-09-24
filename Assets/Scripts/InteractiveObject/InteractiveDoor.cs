using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : InteractiveObject
{ 
    public Transform doorNext;

    public override void Start()
    {
        base.Start();
        ShowAvailable += DoorOpenEvent;
    }

    protected void DoorOpenEvent()
    {
        InteractiveEvent interactiveEvent = new("Leave", "description");
        interactiveEvent.eventContent += () =>
        {
            Player.Instance.transform.position = doorNext.transform.position;
        };
        InteractiveEvents.Add(interactiveEvent);
    }

    
}
