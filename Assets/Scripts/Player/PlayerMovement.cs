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
        // �÷��̾� �Է� ���� (A, D Ű)
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // �Ϲ����� �¿� ������ ó��
        rb.velocity = new Vector2(movement.x * MOVEPSPEED, rb.velocity.y);
    }

    public void MovePlayer2Target(Transform targetPosition)
    {
        StartCoroutine(Move2Target(targetPosition));
    }

    private IEnumerator Move2Target(Transform targetPosition)
    {
        //��ǥ�κ��� 0.1 ���Ϸ� �������ų�, Ű���� ������ �ֱ� ������ �ݺ�
        while (Mathf.Abs(transform.position.x - targetPosition.position.x) > 0.1f 
            && movement.x == 0)
        {
            // �÷��̾ Ÿ���� x ��ǥ �������� �̵���ŵ�ϴ�. 
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(targetPosition.position.x, transform.position.y, transform.position.z),
                Time.deltaTime * MOVEPSPEED);

            yield return null;
        }
    }
}