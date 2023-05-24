using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Represents the game data and state.
/// </summary>
[CreateAssetMenu(fileName = "GameData", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField] private int activeFruits;
    [SerializeField] private bool changeSceen;
    [SerializeField] private bool isDead;

    /// <summary>
    /// The number of active fruits in the game.
    /// </summary>
    public int ActiveFruits
    {
        get { return activeFruits; }
        set { activeFruits = value; }
    }

    /// <summary>
    /// Indicates whether the scene should be changed.
    /// </summary>
    public bool ChangeSceen
    {
        get { return changeSceen; }
        set { changeSceen = value; }
    }

    /// <summary>
    /// Indicates whether the player is dead.
    /// </summary>
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }
}