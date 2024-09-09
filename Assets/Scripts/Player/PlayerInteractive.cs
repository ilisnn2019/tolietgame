using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        // 클릭된 오브젝트에서 IInteractable 인터페이스가 있는지 확인
        if (hit.collider != null && hit.collider.TryGetComponent<IInteractive>(out var interactable))
        {

            // 마우스 왼쪽 버튼 클릭을 감지
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
