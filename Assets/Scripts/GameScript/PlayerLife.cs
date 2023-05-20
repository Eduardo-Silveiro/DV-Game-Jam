using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{

    [SerializeField] private float health = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float scale = 2f;
    [SerializeField] private Transform objectTransform;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private int minusScore = 10;
    private Vector3 newScale;

    private bool isDead;

    //[SerializeField] private AudioSource playerDeathSound;

    //[SerializeField] private AudioSource deathsound;

    private PlayerMovement playerMovement;

    private void Start()
    {
        newScale = objectTransform.localScale;
        isDead = false;
        currentHealth = health;
        playerMovement = GetComponent<PlayerMovement>(); 

    }

    void Update()
    {
        
        if (currentHealth <= 0 && isDead == false)
        {
            isDead = true;
            //animator.SetTrigger("Death");
            //playerDeathSound.Play();
            SceneManager.LoadScene("GameOverScreen");

        }
        if (isDead == true)
        {
            GetComponent<PlayerMovement>().SetCanMove(false);
            //animator.SetBool("canAnimate", false);
            Die();
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SetBellyScale();

        if (currentHealth == 50) {
            playerMovement.SetSpeed(1.9f);
        }
        if (currentHealth == 20) {
            playerMovement.SetSpeed(1.8f);
        }

        Debug.Log("Player Health:" + currentHealth);

        if (playerData.Score-minusScore >= 0 )
        {

            playerData.Score -= minusScore;
        }
        if (playerData.Score - minusScore < 0) {
            playerData.Score = 0;
        }
    }

    public void SetBellyScale() {
        newScale.x *= scale;
        newScale.y = -0.45f;
        newScale.z *= scale;
        objectTransform.localScale = newScale;
    }

    public void IncreaseCurrentLife(float amount)
    {
        if (currentHealth < 100 && isDead == false)
        {
            currentHealth += amount;
            if (currentHealth > 100)
            {
                currentHealth = 100;
            }
        }
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Player died");
    }
}
