using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0; 

    public static GameManager instance;

    public GameObject gameOverScene;

    public GameObject Tutorial;

    public GameObject Score;

    public GameObject Pause;

    public bool started = false;

    public bool paused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the singleton instance
        }

        Time.timeScale = 1f;

        Tutorial.SetActive(true); 
        gameOverScene.SetActive(false); 
        Score.SetActive(false); 
        Pause.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0f;
                Pause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                Pause.SetActive(false);
            }
        }
    }
    public void StartGame()
    {
        Tutorial.SetActive(false); 
        Score.SetActive(true);
        started = true;
    }

    public void GameOver()
    {
        gameOverScene.SetActive(true); 

        Time.timeScale = 0f; // pause the game
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restart
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // load the main menu
    }

}
