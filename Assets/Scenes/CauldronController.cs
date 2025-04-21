using UnityEngine;

public class CauldronController : MonoBehaviour
{
    public Camera mainCam;
    public float yOffsetFromBottom = 1f;
    public float leftEdgeX = -5f;
    public float moveSpeed = 1f;
    public float moveRange = 6f;

    void Start()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }

        // Start at the left edge
        transform.position = new Vector3(leftEdgeX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        // Stick to bottom of the camera
        float camBottomY = mainCam.transform.position.y - mainCam.orthographicSize + yOffsetFromBottom;

        // Horizontal ping-pong motion starting from left
        float x = leftEdgeX + Mathf.PingPong(Time.time * moveSpeed, moveRange);

        transform.position = new Vector3(x, camBottomY, transform.position.z);
    }
}