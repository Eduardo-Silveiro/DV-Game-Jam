using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the pause menu functionality in the game.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool paused = false;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject controlsMenuPanel;

    /// <summary>
    /// Initializes the time scale at the start of the game.
    /// </summary>
    void Start()
    {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Handles input for pausing/unpausing the game and opening/closing the controls menu.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (controlsMenuPanel.activeSelf)
            {
                ControlsBack();
            }
            else if (paused)
            {
                PlayGame();
            }
            else
            {
                StopGame();
            }
        }
    }

    /// <summary>
    /// Resumes the game and hides the pause menu.
    /// </summary>
    public void PlayGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        playerUI.SetActive(true);
        AudioListener.pause = false;
    }

    /// <summary>
    /// Pauses the game and displays the pause menu.
    /// </summary>
    public void StopGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        playerUI.SetActive(false);
        AudioListener.pause = true;
    }

    /// <summary>
    /// Opens the controls menu and hides the pause menu.
    /// </summary>
    public void ControlsMenu()
    {
        pauseMenuPanel.SetActive(false);
        controlsMenuPanel.SetActive(true);
    }

    /// <summary>
    /// Closes the controls menu and shows the pause menu.
    /// </summary>
    public void ControlsBack()
    {
        pauseMenuPanel.SetActive(true);
        controlsMenuPanel.SetActive(false);
    }

    /// <summary>
    /// Returns to the main menu scene and resumes the game.
    /// </summary>
    public void MainMenuComeBack()
    {
        SceneManager.LoadScene("MainMenu");
        paused = false;
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Restarts the current scene and resumes the game.
    /// </summary>
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        paused = false;
    }

    /// <summary>
    /// Restarts the game scene and resumes the game.
    /// </summary>
    public void TryAgain()
    {
        SceneManager.LoadScene("GameScreen");
        paused = false;
    }
}