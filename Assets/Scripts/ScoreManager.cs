using UnityEngine;
using TMPro; // Important for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int currentScore = 0;

    void Start()
    {
        UpdateScoreText(); // Initialize the displayed score
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
 
}