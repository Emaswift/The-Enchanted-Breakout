using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < Camera.main.transform.position.y - 10f)
        {
            Destroy(gameObject);
        }
    }
}