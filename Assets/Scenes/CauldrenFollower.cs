using UnityEngine;

public class CauldronFollower : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 5f;
    public float yOffsetFromBottom = 1f;

    private Camera mainCam;
    private float xCenter;

    void Start()
    {
        mainCam = Camera.main;
        xCenter = transform.position.x;
    }

    void Update()
    {
        // Calculate bottom of the camera in world space
        float bottomY = mainCam.transform.position.y - mainCam.orthographicSize + yOffsetFromBottom;

        // Side-to-side motion
        float x = Mathf.PingPong(Time.time * moveSpeed, moveRange) - (moveRange / 2);
        transform.position = new Vector3(xCenter + x, bottomY, transform.position.z);
    }
}