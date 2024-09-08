using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    public GameObject parent;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        // Ŭ���� ������Ʈ���� IInteractable �������̽��� �ִ��� Ȯ��
        if (hit.collider != null && hit.collider.TryGetComponent<IInteractive>(out var interactable))
        {
            if (interactable.IsInteractive)
            {
                // ���콺 ���� ��ư Ŭ���� ����
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.Interact(parent);
                }
            }
        }
    }
}
