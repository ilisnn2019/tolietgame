using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    void InitEvent();

    abstract void Interactive(GameObject player);

    bool IsInteractive { get; set; }
}
