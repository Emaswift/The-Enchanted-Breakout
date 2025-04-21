using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float scrollSpeed = 0.1f; // Speed at which the camera moves up
    private bool startScrolling = false;

    void Start()
    {
        StartCoroutine(DelayedStart());
    }

    System.Collections.IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(2f);
        startScrolling = true;
    }

    void LateUpdate()
    {
        if (startScrolling)
        {
            transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        }
    }
}