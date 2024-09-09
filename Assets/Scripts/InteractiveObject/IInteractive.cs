using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    abstract void Interactive(GameObject player);

    bool IsInteractive { get; set; }
}
