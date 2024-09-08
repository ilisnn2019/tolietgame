using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const int BLOCK_SIZE = 1;

    public float moveSpeed = 5f; // �¿� �̵� �ӵ�
    public float climbSpeed = 5f; // ��� ���������� �ӵ�

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
        // �÷��̾� �Է� ���� (A, D Ű)
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
            // ����� �������� ���� ������ ó��
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y*climbSpeed);
        }
        else
        {
            // �Ϲ����� �¿� ������ ó��
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        }
    }

    // ��ܿ� �������� ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stairs"))
        {
            isClimbing = !isClimbing;
        }
    }
}