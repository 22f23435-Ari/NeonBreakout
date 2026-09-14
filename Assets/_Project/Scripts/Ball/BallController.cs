using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float launchSpeed = 6f;
    [SerializeField] private Vector2 launchDirection = new Vector2(0.8f, 1f);

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        Vector2 direction = launchDirection.normalized;
        rb.linearVelocity = direction * launchSpeed;
    }
}