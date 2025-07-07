using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene when the player clicks "Start Game"
        SceneManager.LoadScene("Game");
    }
}
