using UnityEngine;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CauldronController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // So it doesn't fall
        rb.linearVelocity = Vector2.right * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EdgeLeft" || collision.gameObject.name == "EdgeRight")
        {
            // Reverse direction
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
        }
    }
}
