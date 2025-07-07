using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0; // Player's score

    public static GameManager instance;

    public GameObject gameOverScene;

    public GameObject Tutorial;

    public GameObject Score;

    public bool started = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the singleton instance
        }

        Time.timeScale = 1f;

        Tutorial.SetActive(true); // Activate the tutorial UI
        gameOverScene.SetActive(false); // Deactivate the Game Over scene
        Score.SetActive(false); // Deactivate the score UI
    }

    public void StartGame()
    {
        Tutorial.SetActive(false); // Deactivate the tutorial UI
        Score.SetActive(true);
        started = true;
    }

    public void GameOver()
    {
        gameOverScene.SetActive(true); // Activate the Game Over scene
        Score.SetActive(false); // Deactivate the score UI

        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }

}
