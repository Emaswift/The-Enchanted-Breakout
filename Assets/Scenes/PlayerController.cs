using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    public int score = 0;
    public Text scoreText;
    
    public int hearts = 3;

    public void LoseHeart()
    {
        hearts--;
        Debug.Log("Ouch! Hearts left: " + hearts);

        if (hearts <= 0)
        {
            Debug.Log("Game Over!");
            // Trigger game over logic here
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreUI();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // fixed from "linearVelocity"

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // fixed here too
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Potions: " + score.ToString();
    }
}