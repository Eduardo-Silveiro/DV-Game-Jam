using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Represents the win screen in the game.
/// </summary>
public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private PlayerData playerData;

    /// <summary>
    /// Called before the first frame update.
    /// Sets up the win screen by displaying the score and high score.
    /// </summary>
    void Start()
    {
        // Display the score on the win screen
        scoreText.text = "Score: " + playerData.Score;

        // Display the high score on the win screen
        highScoreText.text = "High Score: " + playerData.HighScore;
    }
}