using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyFollow : MonoBehaviour
{

    public Transform target;
    float moveSpeed = 2f;
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

        target = FindClosestEnemy();

        //if (transform.tag == "Team1")
        //{
        //    target = GameObject.FindGameObjectWithTag("Team2").GetComponent<Transform>();
        //}
        //else
        //{
        //    target = GameObject.FindGameObjectWithTag("Team1").GetComponent<Transform>();
        //}
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
       


    }

    // Update is called once per frame
    void Update()
    {

        GravityForce();

       

        if (isAlive())
        {
            switch (currentState)
            {
                case AnimalState.Iddle:
                    Iddle();
                    break;
                case AnimalState.Searching:
                    Move();
                    break;
                case AnimalState.Attacking:
                    Attack();
                    break;
           

            }
        }

    }

    private bool isAlive()
    {
        if (transform.gameObject.layer != 11)
        {
            return true;
        }
        else
        {
            return false;
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

    void Iddle() {

        transform.position = currentPos;
        animator.SetFloat("MovementSpeed", 0);
        animator.SetBool("isAttacking", false);
        target = FindClosestEnemy();
        if(target != null)
        {
            currentState=AnimalState.Searching;
        }

    }



    public Transform FindClosestEnemy()
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
        Debug.Log(gos.Length);
        
        GameObject closest = null;
        float infdistance = Mathf.Infinity; /*Vector3.Distance(transform.position, target.position);*/
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
           
           
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            Debug.Log("Vzdalenost: " + infdistance);
            Debug.Log("Current vzdalenost: " + curDistance);
            if (curDistance < infdistance)
            {
                if (go.layer != 11)
                {
                    closest = go;

                    infdistance = curDistance;
                }
            }
        }
        Debug.Log(closest);
        return closest.transform;
    }

    void Move()
    {

        //Debug.Log("hybu se ");
        currentState = AnimalState.Searching;
         distance = Vector3.Distance(transform.position, target.position);

      


        if (distance < maxDist && distance > minDist && target.gameObject.layer != 11)

        {

            transform.LookAt(target);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            animator.SetFloat("MovementSpeed", 0.5f);

        }
        else if (distance < minDist && target.gameObject.layer != 11)
        {

            Debug.Log("utocim");
            currentState = AnimalState.Attacking;
        }
       
    }
    void Attack()
    {
        if (target.gameObject.layer == 11)
        {
            target = null;
            Debug.Log("Flakam se");
            currentState = AnimalState.Iddle;
        }
        else
        {
            animator.SetFloat("AttackType", attackType);

            animator.SetBool("isAttacking", true);
        }
       
    }

   
   
}
