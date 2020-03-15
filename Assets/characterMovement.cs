﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 100f;
    private float currentSpeed = 0f;
    private float speedSmoothVelocity = 0f;
    private float speedSmoothTime = 0.1f;
    private float rotationSpeed = 0.1f;
    private float gravity = 6f;

    private CharacterController controller;
    private Animator animator;
    private Transform mainCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (Input.GetKey(KeyCode.Space))
        {
            Attack();
        }
        else
        {
            animator.SetBool("isAttacking", false);
            Move();
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {

            HardAttack();
        }
        else
        {
            animator.SetBool("isHardAttacking", false);
            Move();
        }


    }

    private void Move()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;
        forward.y = 0;
        right.y =0;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
        Vector3 gravityVector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }
        if (desiredMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);

        }
        float targetSpeed = movementSpeed * movementInput.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);

        controller.Move(gravityVector * Time.deltaTime);

        animator.SetFloat("MovementSpeed", 0.5f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
       

      
    }
    void Attack()
    {
        animator.SetBool("isAttacking", true);
    }
    void HardAttack()
    {
        animator.SetBool("isHardAttacking", true);
    }

}
