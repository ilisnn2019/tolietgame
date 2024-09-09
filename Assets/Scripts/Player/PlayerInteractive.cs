using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        // Ŭ���� ������Ʈ���� IInteractable �������̽��� �ִ��� Ȯ��
        if (hit.collider != null && hit.collider.TryGetComponent<IInteractive>(out var interactable))
        {

            // ���콺 ���� ��ư Ŭ���� ����
            if (Input.GetMouseButtonDown(0))
            {
                if (interactable.IsInteractive)
                {
                    interactable.Interactive(Player.Instance);
                }
                else
                {
                    Player.Move2Target(hit.transform);
                }

            }

        }
    }
}
