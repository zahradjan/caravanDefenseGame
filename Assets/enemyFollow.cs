using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{

    public Transform target;
    float moveSpeed = 1f;
    float maxDist = 5;
    float minDist = 2;
    private CharacterController controller;
    private float verticalVelocity;
    private Animator animator;
    private float gravity = 6f;
    Vector3 currentPos;
 


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        Move();


         







    }

    void Move()
    {
        Vector3 gravityVector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }
        currentPos = transform.position;

        controller.Move(gravityVector * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < maxDist && Vector3.Distance(transform.position, target.position) > minDist)
        {
            
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            animator.SetFloat("MovementSpeed", 0.5f);
        } else
        {
            transform.position = currentPos;
            animator.SetFloat("MovementSpeed", 0);
        }


            if (Vector3.Distance(transform.position, target.position) < minDist)
        {
        //    transform.position += transform.forward * moveSpeed * Time.deltaTime;

            //animator.SetFloat("MovementSpeed", 0.5f);
            animator.SetBool("isAttacking", true);

        } else
        {
            animator.SetBool("isAttacking", false);
        }

        //transform.position = currentPos;
        //animator.SetBool("isAttacking", true);
       
       


    }
}
