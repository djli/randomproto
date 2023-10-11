using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Score variable to keep track of score
    private int score = 0;

    // Text UI element to display the score
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    // Function to add score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Function to update the score text UI
    private void UpdateScoreText()
    {
        scoreText.text = "Time: " + player.timer.ToString() + "\nScore: " + score.ToString();
        if (player.timer <= 0f)
        {
            scoreText.text = "Game Over!\nFinal Score: " + score.ToString();
            Time.timeScale = 0f;
        }
    }
}