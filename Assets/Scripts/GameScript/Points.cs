using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Represents a points prefab in the game.
/// </summary>
[CreateAssetMenu(fileName = "Points", menuName = "Points Prefab")]
public class Points : ScriptableObject
{
    [SerializeField] private int points;

    /// <summary>
    /// Gets or sets the points value.
    /// </summary>
    public int Point
    {
        get { return points; }
        set { points = value; }
    }
}