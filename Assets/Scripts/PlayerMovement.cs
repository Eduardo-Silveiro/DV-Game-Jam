using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float smothMovTime;
    [SerializeField] private float smothSpeed;
    private Animator animator;
    private bool canMove;
    [SerializeField] AudioSource playerSteps;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
       
        smothMovTime = 0.1f;
        canMove = true;
        
    }

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

    public void SetCanMove(bool canMove) {
        this.canMove = canMove;
    }

    
}
