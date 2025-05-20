using UnityEngine;
using UnityEngine;

public class CameraEdgePlacer : MonoBehaviour
{
    public GameObject leftEdgeObject;
    public GameObject rightEdgeObject;
    public float offset = 0f; // Optional padding from the edge

    void Start()
    {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        Vector3 camPos = cam.transform.position;

        if (leftEdgeObject)
            leftEdgeObject.transform.position = new Vector3(camPos.x - camWidth / 2 + offset, camPos.y, 0);

        if (rightEdgeObject)
            rightEdgeObject.transform.position = new Vector3(camPos.x + camWidth / 2 - offset, camPos.y, 0);
    }
}
