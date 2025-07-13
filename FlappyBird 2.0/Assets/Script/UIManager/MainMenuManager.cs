using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{

    public GameObject ControlScene;

    public GameObject MainMenuScene;

    public bool controlsActive = false;

    private void Start()
    {
        MainMenuScene.SetActive(true); // Ensure the main menu scene is active at the start
        controlsActive = false; // Initialize controlsActive to false
        ControlScene.SetActive(false); // Ensure the controls menu is hidden at the start
    }
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }

    public void ControlMenu()
    {
        controlsActive = !controlsActive; // Toggle the controls menu visibility
        if (controlsActive)
        {
            ControlScene.SetActive(true); // Show the controls menu
            MainMenuScene.SetActive(false); // Hide the main menu scene
        }
        else
        {
            ControlScene.SetActive(false); // Hide the controls menu
            MainMenuScene.SetActive(true);
        }
    }
}
