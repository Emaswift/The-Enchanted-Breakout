using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public float speed = 2f;
    public float moveRange = 3f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float move = Mathf.PingPong(Time.time * speed, moveRange);
        transform.position = startPos + new Vector3(move, 0, 0);
    }

}