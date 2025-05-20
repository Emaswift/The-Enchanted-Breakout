using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;


    public GameObject[] heartsUI;
    public int hearts = 3;
    private bool isInvincible = false;

    public GameObject gameOverScreen;
    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isGameOver) return;

        float moveInput = Input.GetAxis("Horizontal");

        // Move player
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (Mathf.Abs(moveInput) > 0)
        {
            spriteRenderer.flipX = moveInput > 0;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            LoseHeart();
        }
    }
    public void LoseHeart()
    {
        if (isInvincible)
            return;
        
        hearts--;
        Debug.Log("Ouch! Hearts left: " + hearts);
        for (int i = 0; i < heartsUI.Length; i++)
        {
            heartsUI[i].SetActive(hearts > i);
            
        }

        if (hearts <= 0 && !isGameOver)
        {
            Debug.Log("Game Over!");
            isGameOver = true;
            if (gameOverScreen != null) gameOverScreen.SetActive(true);
            // Time.timeScale = 0f; // -> if you don't set this back to 1 it will pause the game forever
            return; // so that we don't trigger invincibily if we're dead
        }

        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        isInvincible = true;

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.color = Color.clear;
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.color = Color.white;
        }
        
        isInvincible = false;
    }
}

    

    