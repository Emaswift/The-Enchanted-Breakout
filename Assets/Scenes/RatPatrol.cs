using UnityEngine;

public class RatPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 3f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float direction = movingRight ? 1f : -1f;
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, startPos) >= patrolDistance)
        {
            movingRight = !movingRight;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}