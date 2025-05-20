using System;
using TMPro;
using UnityEngine;

public class PotionCollector : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    private void Start()
    {
        UpdateScoreUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            Debug.Log("Potion collected!");
            Destroy(other.gameObject); // remove the potion from the scene
            AddScore(1);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}

