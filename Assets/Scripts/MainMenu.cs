using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to start the game, loading scene 1
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    // Method to go back to the main menu, loading scene 0
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
