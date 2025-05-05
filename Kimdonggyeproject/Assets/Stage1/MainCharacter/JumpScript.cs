using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float initialJumpForce = 5f;
    public float holdJumpForce = 10f;
    public float maxHoldTime = 0.3f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isJumping = false;
    private float jumpHoldTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool isGrounded = IsGrounded();

        // ���� ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // ���� ��ø ����
            rb.AddForce(Vector3.up * initialJumpForce, ForceMode.Impulse);
            isJumping = true;
            jumpHoldTimer = 0f;
        }

        // ���� �� ���� �� ���ϱ�
        if (Input.GetKey(KeyCode.Space) && isJumping && jumpHoldTimer < maxHoldTime)
        {
            rb.AddForce(Vector3.up * holdJumpForce * Time.deltaTime, ForceMode.Acceleration);
            jumpHoldTimer += Time.deltaTime;
        }

        // ���� �ߴ� ����
        if (Input.GetKeyUp(KeyCode.Space) || jumpHoldTimer >= maxHoldTime)
        {
            isJumping = false;
        }
    }

    // �ٴ� ����
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    // ����׿� Ray ǥ��
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
