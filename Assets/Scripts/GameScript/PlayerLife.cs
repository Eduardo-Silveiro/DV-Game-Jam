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
    private PlayerData playerData;
    [SerializeField] private int minusScore = 10;
    private Vector3 newScale;

    //[SerializeField] private Animator animator;
    private bool isDead;

    //[SerializeField] private AudioSource playerDeathSound;

    //private TMP_Text text;
    //[SerializeField] private AudioSource deathsound;

    private PlayerMovement playerMovement;

    private void Start()
    {
        newScale = objectTransform.localScale;
        isDead = false;
        currentHealth = health;
        //objectTransform = GetComponent<Transform>();
       //animator.SetBool("canAnimate", true);
       playerMovement = GetComponent<PlayerMovement>(); 

    }

    void Update()
    {
        //healthBar.fillAmount = Mathf.Clamp(currentHealth / health, 0, 1);
        
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
       /* if (playerData.Score > 0)
        {
            playerData.Score -= minusScore;
        }*/
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
        //SceneManager.LoadScene("GameOver");
        Debug.Log("Player died");
    }
}
