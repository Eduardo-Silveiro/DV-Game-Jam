using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{

    [SerializeField] private float health = 100f;
    [SerializeField] private float currentHealth;
    
    //[SerializeField] private Animator animator;
    private bool isDead;

    //[SerializeField] private AudioSource playerDeathSound;

    //private TMP_Text text;
    //[SerializeField] private AudioSource deathsound;

    private void Start()
    {
        isDead = false;
        currentHealth = health;
        
       //animator.SetBool("canAnimate", true);

    }

    void Update()
    {
        //healthBar.fillAmount = Mathf.Clamp(currentHealth / health, 0, 1);
        
        if (currentHealth <= 0 && isDead == false)
        {
            isDead = true;
            //animator.SetTrigger("Death");
            //playerDeathSound.Play();

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

        Debug.Log("Player Health:" + currentHealth);

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
        //SceneManager.LoadScene("GameOver");
        Debug.Log("Player died");
    }
}
