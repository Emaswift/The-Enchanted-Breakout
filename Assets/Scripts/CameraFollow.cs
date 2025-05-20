using UnityEngine;

public class C_ameraFollow : MonoBehaviour
{
    public Transform target;        // Player's transform (Princess Poppy)
    public float smoothSpeed = 2f;  // How smoothly camera follows
    public float yOffset = 2f;      // Camera stays a little ahead

    void LateUpdate()
    {
        if (target != null)
        {
            // Only follow Y upward (never move down)
            float desiredY = Mathf.Max(transform.position.y, target.position.y + yOffset);
            Vector3 targetPosition = new Vector3(transform.position.x, desiredY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}