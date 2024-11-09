using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �÷��̾ ���������� ������ �� �� ����ϴ� ��ũ��Ʈ
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
    /// ������Ʈ Ŭ����, �÷��̾ �ش� ������Ʈ�� ���� �̵�
    /// </summary>
    /// <param name="targetPosition">������Ʈ ��ġ</param>
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
