using UnityEngine;

public class Potion : MonoBehaviour
{
    private bool isHeld = false;
    private Rigidbody2D rb;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isHeld && transform.parent != null)
        {
            transform.position = transform.parent.position;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Drop();
            }
        }
    }

    public void PickUp(Transform holdPoint)
    {
        isHeld = true;
        transform.SetParent(holdPoint);
        rb.isKinematic = true;
        col.enabled = false;
        Debug.Log("Potion picked up!");
    }

    public void Drop()
    {
        isHeld = false;
        transform.SetParent(null);
        rb.isKinematic = false;
        col.enabled = true;
        Debug.Log("Potion dropped!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHeld && other.CompareTag("Cauldron"))
        {
            Debug.Log("Potion delivered!");

            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                player.AddScore(1);
            }

            Destroy(gameObject);
        }
    }
}


