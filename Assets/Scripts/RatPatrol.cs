using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RatPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 3f;

    private Rigidbody2D rb;
    private Vector2 leftPoint;
    private Vector2 rightPoint;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        Vector2 start = transform.position;
        leftPoint = start - Vector2.right * patrolDistance / 2f;
        rightPoint = start + Vector2.right * patrolDistance / 2f;
    }

    void FixedUpdate()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, 0f);
            if (transform.position.x >= rightPoint.x)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, 0f);
            if (transform.position.x <= leftPoint.x)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}