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

    public static PlayerUI pu;

    private void Awake()
    {
        Instance = gameObject;
        pm = GetComponent<PlayerMovement>();
        pi = GetComponent<PlayerInteractive>();
        ps = GetComponent<PlayerStatus>();
        pu = GetComponent<PlayerUI>();
    }

    /// <summary>
    /// 오브젝트 클릭시, 플레이어가 해당 오브젝트를 향해 이동
    /// </summary>
    /// <param name="targetPosition">오브젝트 위치</param>
    public static void Move2Target(Transform targetPosition)
    {
        pm.MovePlayer2Target(targetPosition);
    }

    public static void ChangePlayerVital(float deltha)
    {
        float currentVital = ps.ChangeVital(deltha);
        pu.UpdateVitalSlider(currentVital);
    }

    public static void ChangePlayerStemina(float deltha)
    {
        ps.ChangeStemina(deltha);
    }
    public static void ChangePlayerHunger(float deltha)
    {
        ps.ChangeHunger(deltha);
    }
    public static void ChangePlayerThirsty(float deltha)
    {
        ps.ChangeThirsty(deltha);
    }
    public static void ChangePlayerMental(float deltha)
    {
        ps.ChangeMental(deltha);
    }
}
