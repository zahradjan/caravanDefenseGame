using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyFollow : MonoBehaviour
{

    public Transform target;
    float moveSpeed = 1f;
    float maxDist = 10;
    float minDist = 2f;
    private CharacterController controller;
    private float verticalVelocity;
    private Animator animator;
    private float gravity = 6f;
    Vector3 currentPos;
    int attackType;
    float attackTimer;
    public HealthBar healthBar;
    float distance;

    public enum AnimalState
    {
        Iddle,
        Searching,
        Attacking,
        Death
    }


    public AnimalState currentState;




    // Start is called before the first frame update
    void Start()
    {

        currentState = AnimalState.Searching;
        if (transform.tag == "Team1")
        {
            target = GameObject.FindGameObjectWithTag("Team2").GetComponent<Transform>();
        } else
        {
            target = GameObject.FindGameObjectWithTag("Team1").GetComponent<Transform>();
        }
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
       


    }

    // Update is called once per frame
    void Update()
    {

        GravityForce();

        switch (currentState)
        {
            case AnimalState.Iddle:

                break;
            case AnimalState.Searching:
                EnemyMove();
                break;
            case AnimalState.Attacking:
                EnemyAttack();
                break;
            case AnimalState.Death:
                Death();
                break;
            
        }



       

      


    }

    void GravityForce()
    {
        Vector3 gravityVector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }
        controller.Move(gravityVector * Time.deltaTime);

        currentPos = transform.position;



    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        if (transform.tag == "Team1")
        {

            gos = GameObject.FindGameObjectsWithTag("Team2");
        }
        else
        {
            gos = GameObject.FindGameObjectsWithTag("Team1");
        }

        
        GameObject closest = null;
        distance = Vector3.Distance(transform.position, target.position);
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void EnemyMove()
    {

        FindClosestEnemy();
       

        if (distance < maxDist && distance > minDist && target.gameObject.layer != 11)

        {
            
            transform.LookAt(target);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            animator.SetFloat("MovementSpeed", 0.5f);
            
        }
        else if (distance < minDist && target.gameObject.layer != 11)
        {
            currentState = AnimalState.Attacking;
        } else
        {
            transform.position = currentPos;
            animator.SetFloat("MovementSpeed", 0);
        } 
       
    }
    void EnemyAttack()
    {
       
        distance = Vector3.Distance(transform.position, target.position);



        if (distance < minDist &&  target.gameObject.layer != 11)
        {
            attackTimer++;
            if (attackTimer > 80)
            {
             //   attackType = Random.Range(0, 5);
                attackTimer = 0;
            } 
        
            
           // Debug.Log(attackTimer);
         //   if (!animator.GetBool("isAttacking"))
         //   {
                animator.SetFloat("AttackType",attackType);
             
                 animator.SetBool("isAttacking", true);
                
          //  }
           

        }
        else
        {
            animator.SetBool("isAttacking", false);
        }


         
        
    }

   
    void Death()
    {
      
        if (animator.GetBool("isDead") == false )
        {
            EnemyMove();

            EnemyAttack();
        }
    }
}
