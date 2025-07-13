using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public int highScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // load high score from PlayerPrefs
        highScoreText.text = highScore.ToString();
    }

    private void Update()
    {
        updateScore();
    }

    private void updateScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score); // save new high score
        }
        highScore = PlayerPrefs.GetInt("HighScore", 0); // get the high score from PlayerPrefs

        scoreText.text = score.ToString(); // update the score display
        highScoreText.text = highScore.ToString(); // update the high score display
    }
}
