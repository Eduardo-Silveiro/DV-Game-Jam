using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the game over menu functionality in the game.
/// </summary>
public class GameOverMenu : MonoBehaviour
{
    /// <summary>
    /// Restarts the game by loading the "Game" scene.
    /// </summary>
    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Returns to the main menu by loading the "MainMenu" scene.
    /// </summary>
    public void MainMenuComeBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}