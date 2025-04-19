using UnityEngine;

public class CauldronController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float leftLimit = -8f;
    public float rightLimit = 8f;

    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= rightLimit)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= leftLimit)
                movingRight = true;
        }
    }
}

