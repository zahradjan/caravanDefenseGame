using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherControl : MonoBehaviour
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
    private ShootProjectile shootp;


    public enum AnimalState
    {
        Iddle,
        Attacking,
        Death
    }
    public AnimalState currentState;



    // Start is called before the first frame update
    void Start()
    {


        currentState = AnimalState.Iddle;
        // u archera neni nutne protoze jde rovnou do stavu idle kde si to hleda
        //target = FindClosestEnemy();

        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        shootp = GetComponent<ShootProjectile>();
       



    }
 

    void Update()
    {

        GravityForce();



        //Debug.Log("CAS U: " + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        if (IamAlive())
        {
            switch (currentState)
            {
                case AnimalState.Iddle:
                    Iddle();
                    break;
                case AnimalState.Attacking:
                    Attack();
                    break;


            }
        }

    }






    void Iddle()
    {

        transform.position = currentPos;
        animator.SetFloat("MovementSpeed", 0);
        animator.SetBool("isAttacking", false);
        target = FindClosestEnemy();
        if (target != null)
        {
            currentState = AnimalState.Attacking;
        }

    }





    void Attack()
    {
        if (TargetIsDead(target))
        {
            target = null;
          
            currentState = AnimalState.Iddle;
        }
        else
        {


            transform.LookAt(target);
            animator.SetBool("isAttacking", true);
         


        }


    }

    // tyto metody jsou u archera navic protoze dostreli az na konec placu a hnedle vidi a nepotrebuje k nepriteli chodit
    //private bool TargetIsInAttackRange()
    //{
    //    return distance < minDist && !TargetIsDead();
    //}

    //private bool TargetIsVisible()
    //{
    //    return distance < maxDist && distance > minDist && !TargetIsDead();
    //}



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
        //Debug.Log(gos.Length);

        GameObject closest = null;
        float infdistance = Mathf.Infinity; /*Vector3.Distance(transform.position, target.position);*/
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {


            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            //Debug.Log("Vzdalenost: " + infdistance);
            //Debug.Log("Current vzdalenost: " + curDistance);
            if (curDistance < infdistance)
            {
                if (go.layer != 11)
                {
                    closest = go;

                    infdistance = curDistance;
                }
            }
        }
        //Debug.Log(closest);
        if (closest != null)
        {
            return closest.transform;
        }
        else
        {
            return null;
        }

    }









   public void GravityForce()
    {
        Vector3 gravityVector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }
        controller.Move(gravityVector * Time.deltaTime);

        currentPos = transform.position;



    }
    public bool IamAlive()
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
    public bool TargetIsDead(Transform target)
    {
        if (target.gameObject.layer == 11)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
