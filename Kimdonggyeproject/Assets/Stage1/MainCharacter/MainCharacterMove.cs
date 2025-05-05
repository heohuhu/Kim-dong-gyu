using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementRB : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        // Y축 회전만 고정 (필요에 따라 조절 가능)
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W))
            moveZ = 1f;
        if (Input.GetKey(KeyCode.S))
            moveZ = -1f;
        if (Input.GetKey(KeyCode.A))
            moveX = -1f;
        if (Input.GetKey(KeyCode.D))
            moveX = 1f;

        movement = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // 기존 y축 속도 보존 (중력 영향)
        Vector3 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, currentVelocity.y, movement.z * moveSpeed);
    }
}
