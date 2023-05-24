using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the main menu functionality in the game.
/// </summary>
public class MainMenuScript : MonoBehaviour
{
    /// <summary>
    /// Loads the "Game" scene to start a new game.
    /// </summary>
    public void BtnNewGame()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void BtnQuit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Loads the "GameContext" scene to display game instructions or context.
    /// </summary>
    public void BtnGameContext()
    {
        SceneManager.LoadScene("GameContext");
    }
}