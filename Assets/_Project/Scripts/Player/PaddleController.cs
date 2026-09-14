using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float moveInput;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float minX;
    private float maxX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        float halfScreenWidth =
            Camera.main.orthographicSize * Camera.main.aspect;

        float halfPaddleWidth =
            spriteRenderer.bounds.extents.x;

        minX = -halfScreenWidth + halfPaddleWidth;
        maxX = halfScreenWidth - halfPaddleWidth;
    }

    private void Update()
    {
        moveInput = 0f;

        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.leftArrowKey.isPressed ||
            Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;
        }

        if (Keyboard.current.rightArrowKey.isPressed ||
            Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;
        }
    }

    private void FixedUpdate()
    {
        float targetX =
            rb.position.x +
            moveInput * moveSpeed * Time.fixedDeltaTime;

        targetX = Mathf.Clamp(targetX, minX, maxX);

        Vector2 targetPosition =
            new Vector2(targetX, rb.position.y);

        rb.MovePosition(targetPosition);
    }
}