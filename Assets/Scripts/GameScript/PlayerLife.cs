using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the player's life in the game.
/// </summary>
public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float scale = 2f;
    [SerializeField] private Transform objectTransform;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private int minusScore = 10;
    [SerializeField] private GameObject explosion;
    private Vector3 newScale;
    [SerializeField] private GameData gameData;

    private PlayerMovement playerMovement;

    private void Start()
    {
        newScale = objectTransform.localScale;
        gameData.ISDead = false;
        gameData.ChangeSceen = false;
        currentHealth = health;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (currentHealth <= 0 && gameData.ISDead == false && gameData.ChangeSceen == false)
        {
            gameData.ISDead = true;
        }

        if (gameData.ISDead == true)
        {
            GetComponent<PlayerMovement>().SetCanMove(false);
            Die();
            Invoke(nameof(ChangeScene), 1.5f);
            gameData.ISDead = false;
        }
    }

    /// <summary>
    /// Inflicts damage to the player.
    /// </summary>
    /// <param name="damage">The amount of damage to be inflicted.</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SetBellyScale();

        if (currentHealth == 50)
        {
            playerMovement.SetSpeed(1.9f);
        }
        if (currentHealth == 20)
        {
            playerMovement.SetSpeed(1.8f);
        }

        Debug.Log("Player Health: " + currentHealth);

        ScoreChecker();
    }

    /// <summary>
    /// Checks the player's score and deducts points if possible.
    /// </summary>
    public void ScoreChecker()
    {
        if (playerData.Score - minusScore >= 0)
        {
            playerData.Score -= minusScore;
        }
        if (playerData.Score - minusScore < 0)
        {
            playerData.Score = 0;
        }
    }

    /// <summary>
    /// Adjusts the scale of the player's belly.
    /// </summary>
    public void SetBellyScale()
    {
        newScale.x *= scale;
        newScale.y = -0.45f;
        newScale.z *= scale;
        objectTransform.localScale = newScale;
    }

    /// <summary>
    /// Increases the player's current health by the given amount.
    /// </summary>
    /// <param name="amount">The amount to increase the current health.</param>
    public void IncreaseCurrentLife(float amount)
    {
        if (currentHealth < 100 && gameData.ISDead == false)
        {
            currentHealth += amount;
            if (currentHealth > 100)
            {
                currentHealth = 100;
            }
        }
    }

    /// <summary>
    /// Gets the current health of the player.
    /// </summary>
    /// <returns>The current health of the player.</returns>
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// Handles the death of the player.
    /// </summary>
    private void Die()
    {
        gameObject.SetActive(false);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log("Player died");
    }

    /// <summary>
    /// Changes the scene after a delay.
    /// </summary>
    private void ChangeScene()
    {
        gameData.ChangeSceen = true;
    }
}