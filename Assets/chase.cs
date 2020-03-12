using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{
    public Transform player;
    static Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);



        if (Vector3.Distance(player.position, this.transform.position) < 12 && angle < 30)
        {
            
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            
            anim.SetBool("isIddle",false);
            if (direction.magnitude > 8)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isMoving", true);
                anim.SetBool("isAttacking", false);
                print(direction.magnitude);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isMoving", false);
            }
        }
        else
        {
            anim.SetBool("isIddle", true);
            anim.SetBool("isMoving", false);
            anim.SetBool("isAttacking", false);
        }
        
    }
}
