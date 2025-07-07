using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Player's score

    public int highScore = 0; // Player's high score

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Load high score from PlayerPrefs
        highScoreText.text = highScore.ToString(); // Initialize high score display
    }

    private void Update()
    {
        updateScore();
    }

    private void updateScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score); // Save new high score to PlayerPrefs
        }
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Retrieve the high score from PlayerPrefs

        scoreText.text = score.ToString(); // Update the score display
        highScoreText.text = highScore.ToString(); // Update the high score display
    }
}
