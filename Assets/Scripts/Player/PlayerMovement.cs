using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MOVEPSPEED = 3;

    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField]
    private bool isMovable = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 플레이어 입력 감지 (A, D 키)
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // 일반적인 좌우 움직임 처리
        rb.velocity = new Vector2(movement.x * MOVEPSPEED, rb.velocity.y);
    }

    public void MovePlayer2Target(Transform targetPosition)
    {
        StartCoroutine(Move2Target(targetPosition));
    }

    private IEnumerator Move2Target(Transform targetPosition)
    {
        //목표로부터 0.1 이하로 좁혀지거나, 키보드 조작이 있기 전까지 반복
        while (Mathf.Abs(transform.position.x - targetPosition.position.x) > 0.1f 
            && movement.x == 0)
        {
            // 플레이어를 타겟의 x 좌표 방향으로 이동시킵니다. 
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(targetPosition.position.x, transform.position.y, transform.position.z),
                Time.deltaTime * MOVEPSPEED);

            yield return null;
        }
    }
}