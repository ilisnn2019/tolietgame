using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 플레이어에 직간접적인 영향을 줄 때 사용하는 스크립트
/// </summary>
public class Player : MonoBehaviour
{
    public static GameObject Instance;

    public static PlayerMovement pm;

    public static PlayerInteractive pi;

    public static PlayerStatus ps;

    private void Awake()
    {
        Instance = gameObject;
        pm = GetComponent<PlayerMovement>();
        pi = GetComponent<PlayerInteractive>();
        ps = GetComponent<PlayerStatus>();
    }

    public static void Move2Target(Transform targetPosition)
    {
        pm.MovePlayer2Target(targetPosition);
    }

}
