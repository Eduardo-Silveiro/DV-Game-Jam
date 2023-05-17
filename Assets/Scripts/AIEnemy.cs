using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform player;

    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    [SerializeField] private float health = 100f;

    //Patroling
    [SerializeField] private Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] private float walkPointRange;

    //Attacking
    [SerializeField] private float timeBetweenAttacks;
    bool alreadyAttacked;
    [SerializeField] private int meleeDamage = 10;

    //States
    [SerializeField] private float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;

    //Animations
    //private Animator animator;


    // Audio Source
    //[SerializeField] private AudioSource attackSound;
    //[SerializeField] private AudioSource deathSound;



    private void Start()
    {
        //animator = GetComponent<Animator>();
        

    }
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        //animator.SetBool("isAttacked", false);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

            if (!alreadyAttacked)
            {
                if (player.GetComponent<PlayerLife>().GetCurrentHealth() > 0)
                {
                    player.GetComponent<PlayerLife>().TakeDamage(meleeDamage);
                    //animator.SetBool("isAttacked", true);
                    alreadyAttacked = true;
                    //attackSound.Play();
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                }
            }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
/*
    public void TakeDamage(int damage)
    {

        if (health <= 0)
        {
            return; // don't take any more damage if enemy is already dead
        }

        health -= damage;

        if (health <= 0)
        {
            //animator.SetTrigger("isDead");
            isDead = true;


            goldCollector.IncreaseGold(GOLD_VALUE);
            deathSound.Play();
            Invoke(nameof(DestroyEnemy), 2f);


        }

        Debug.Log("Demon" + health);
    }

    private void DestroyEnemy()
    {

        Destroy(gameObject);

    }*/


    /** Draw the Attack Range Line and the Chase Range Line **/
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public float gethealth()
    {
        return health;
    }
}
