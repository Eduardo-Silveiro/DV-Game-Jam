using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages the player in the game.
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData player;
    private int maxScore;
    [SerializeField] private GameData gameData;
    [SerializeField] AudioSource collectSound;
    [SerializeField] private Timer timer;

    /// <summary>
    /// Called before the first frame update.
    /// Initializes player score and high score.
    /// </summary>
    void Start()
    {
        player.Score = 0;
        player.HighScore = PlayerPrefs.GetInt("MaxScore", 0);
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }


    /// <summary>
    /// Called when the player collides with a trigger collider.
    /// Handles collecting fruits, updating score, and saving high score.
    /// </summary>
    /// <param name="other">The collider that the player collided with.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruits"))
        {
            collectSound.Play();
            player.Score += other.gameObject.GetComponent<ItemCollecter>().GetScore();
            other.gameObject.SetActive(false);
            gameData.ActiveFruits--;
            timer.AddTime();
            if (player.Score > maxScore)
            {
                maxScore = player.Score;
                player.HighScore = player.Score;
            }
        }
    }

    /// <summary>
    /// Called when the player object is destroyed.
    /// Saves the maximum score to player preferences.
    /// </summary>
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("MaxScore", maxScore);
        PlayerPrefs.Save();
    }
}