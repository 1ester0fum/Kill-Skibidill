using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 4f;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Преобразуем управление
        // в изометрические направления
        movementInput = new Vector2(
            horizontal - vertical,
            (horizontal + vertical) * 0.5f
        );

        movementInput = movementInput.normalized;
    }

    void FixedUpdate()
    {
        Vector2 newPosition =
            rb.position +
            movementInput * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}
