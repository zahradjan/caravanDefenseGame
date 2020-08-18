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
    private AnimatorClipInfo[] current;
    private AnimatorStateInfo animatorStateInfo ;
    private string currentName;
    private float currentLength;
    private float timepased;
    float actualTimeOfAnimation;

    // Start is called before the first frame update
    void Start()
    {

      
        currentState = AnimalState.Searching;

        target = FindClosestEnemy();
        //attackType =2;/* Random.Range(1, 4);*/

        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
       


    }
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GravityForce();



        //Debug.Log("CAS U: " + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

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
        if(closest != null)
        {
            return closest.transform;
        }
        else
        {
            return null;
        }
       
    }

    void Move()
    {
        if (target.gameObject.layer == 11)
        {
            target = null;
            Debug.Log("Flakam se");
            currentState = AnimalState.Iddle;
        }
        else
        {




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


                animator.SetFloat("MovementSpeed", 0);
                currentState = AnimalState.Attacking;
            }
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



            animator.SetBool("isAttacking", true);




        }

        // zjistit jestli ta aktualni animace utoku uz skoncila a na zaklade toho ji zmenit
        // zmena probehne na zaklade 

        bool AnimatorIsPlaying()
        {

            float completeLengthOfAnimation = animatorStateInfo.length;
            actualTimeOfAnimation = animatorStateInfo.normalizedTime;
            Debug.Log("CL " + completeLengthOfAnimation);
            Debug.Log("AT " + actualTimeOfAnimation);
            return completeLengthOfAnimation > actualTimeOfAnimation;
        }

        IEnumerator changeAttackType(float seconds)
        {

            Debug.Log("Jmeno: " + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + " delka: " + seconds);
            yield return new WaitForSeconds(seconds);

            attackType = Random.Range(1,3);
            //    animator.SetFloat("AttackType", attackType);
        }
    }



}
