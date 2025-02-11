using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseCanvas;
    public Button pauseButton; // Reference to the pause button
    public Button resumeButton; // Reference to the resume button
    public GameObject save;

    void Start()
    {
        Time.timeScale = 1;
        // Ensure the buttons are assigned and add listeners to them
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(TogglePause);
        }

        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeGame);
        }
    }

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
        pauseCanvas.SetActive(isPaused);
        

        if (isPaused == true)
        {
            EventSystem.current.SetSelectedGameObject(save);
        }

        else
        {
            EventSystem.current.SetSelectedGameObject(pauseButton.gameObject);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }
}