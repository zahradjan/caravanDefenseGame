using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{

    public Transform target;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 2;
    private CharacterController controller;
    private float verticalVelocity;
    private float jumpForce = 2f;
    private float gravity = 3f;
    Vector3 currentPos;
 


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);


            if (controller.isGrounded)
            {
                verticalVelocity = -gravity * Time.deltaTime;

                if (Vector3.Distance(transform.position, target.position) < MinDist)
                {
                    
                    verticalVelocity = jumpForce;
                transform.position = currentPos;
                }
            
            
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

      


        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);


        if (Vector3.Distance(transform.position, target.position) > MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            currentPos = transform.position;

        }



    }
}
