using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;

        if (isPaused)
            pauseCanvas.SetActive(true);
        else
            pauseCanvas.SetActive(false);
        // Activate/deactivate the pause menu UI
        // You can use setActive or change canvas alpha to show/hide the pause menu
        // For example:
        // pauseMenuCanvas.SetActive(isPaused);
    }
}
