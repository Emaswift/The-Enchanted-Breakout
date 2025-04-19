using UnityEngine;

public class Potion : MonoBehaviour
{
    private bool isHeld = false;
    private Transform holdPoint;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Potion rigidbody is " + (rb.simulated ? "simulated" : "not simulated"));
    }

    void Update()
    {
        // Follow the HoldPoint while held
        if (isHeld && holdPoint != null)
        {
            transform.position = holdPoint.position;

            // Drop potion with Enter/Return
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isHeld = false;
                transform.SetParent(null);
                rb.simulated = true;
                Debug.Log("Potion dropped!");
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Near player");

        if (!isHeld && other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                holdPoint = other.transform.Find("HoldPoint");

                if (holdPoint != null)
                {
                    isHeld = true;
                    transform.SetParent(holdPoint);
                    rb.simulated = false;
                    Debug.Log("Potion picked up!");
                }
                else
                {
                    Debug.LogWarning("HoldPoint not found on Player!");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHeld && other.CompareTag("Cauldron"))
        {
            Debug.Log("Potion delivered!");

            // Add score when potion hits the cauldron
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                player.AddScore(1);
            }

            Destroy(gameObject);
        }
    }
}


