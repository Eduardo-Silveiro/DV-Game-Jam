using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents player movement in the game.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float smothMovTime;
    [SerializeField] private float smothSpeed;
    private Animator animator;
    private bool canMove;

    private void Start()
    {
        animator = GetComponent<Animator>();

        smothMovTime = 0.1f;
        canMove = true;
    }

    /// <summary>
    /// Update is called once per frame.
    /// Handles player movement based on input.
    /// </summary>
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (movement.magnitude >= 0.1f && canMove == true)
        {
            animator.SetBool("IsMoving", true);

            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smothSpeed, smothMovTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    /// <summary>
    /// Sets the ability to move for the player.
    /// </summary>
    /// <param name="canMove">Whether the player can move or not.</param>
    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    /// <summary>
    /// Gets the current speed of the player.
    /// </summary>
    /// <returns>The speed of the player.</returns>
    public float GetSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Sets the speed of the player.
    /// </summary>
    /// <param name="speed">The new speed value.</param>
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}