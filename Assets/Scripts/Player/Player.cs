using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject Instance;

    public static PlayerMovement pm;

    private void Awake()
    {
        Instance = gameObject;
        pm = GetComponent<PlayerMovement>();
    }

    public static void Move2Target(Transform targetPosition)
    {
        pm.MovePlayer2Target(targetPosition);
    }
}
