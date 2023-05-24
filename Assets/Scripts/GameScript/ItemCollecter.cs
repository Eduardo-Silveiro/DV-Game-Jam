using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Collects items and retrieves the associated score.
/// </summary>
public class ItemCollecter : MonoBehaviour
{
    [SerializeField] private Points scorePoints;

    /// <summary>
    /// Retrieves the score associated with the collected item.
    /// </summary>
    /// <returns>The score value.</returns>
    public int GetScore()
    {
        return scorePoints.Point;
    }
}