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

    public static void ChangePlayerHealth(float deltha)
    {
        ps.ChangeHealth(deltha);
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
