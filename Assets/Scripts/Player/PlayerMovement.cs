using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const int BLOCK_SIZE = 1;

    public float moveSpeed = 5f; // 좌우 이동 속도
    public float climbSpeed = 5f; // 계단 오르내리는 속도

    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField]
    private bool isClimbing = false;
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
        if (isClimbing)
        {
            movement.y = Input.GetAxisRaw("Horizontal");
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            // 계단을 오르내릴 때의 움직임 처리
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y*climbSpeed);
        }
        else
        {
            // 일반적인 좌우 움직임 처리
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        }
    }

    // 계단에 접촉했을 때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stairs"))
        {
            isClimbing = !isClimbing;
        }
    }
}