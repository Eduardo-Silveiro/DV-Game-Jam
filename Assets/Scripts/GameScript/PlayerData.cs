using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Represents the data of the player in the game.
/// </summary>
[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int score;
    [SerializeField] private int highScore;

    /// <summary>
    /// The current score of the player.
    /// </summary>
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    /// <summary>
    /// The highest score achieved by the player.
    /// </summary>
    public int HighScore
    {
        get { return highScore; }
        set { highScore = value; }
    }
}