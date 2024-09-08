using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    abstract void Interact(GameObject player);

    bool IsInteractive { get; set; }
}
