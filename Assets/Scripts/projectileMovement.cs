using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : ArcherControl
{
    public float speed = 20f;
    private Transform target;
    private float targetHeight;
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    // Start is called before the first frame update
    void Start()
    {
        //najde cíl
        target = FindClosestEnemy(transform);
    }

    // Update is called once per frame
    void Update()
    {


        if (!TargetIsDead(target))
        {



            //nastaví rotaci
            offsetX = target.position.x - transform.position.x;
            offsetY = target.position.y + 2 - transform.position.y;
            offsetZ = target.position.z - transform.position.z;
            Vector3 direction = new Vector3(offsetX, offsetY, offsetZ); /*target.transform.position + targetHeight + target.up - transform.position;*/
            Quaternion rotation = Quaternion.LookRotation(direction);

            Debug.Log("Bounds min: " + target.GetComponent<CapsuleCollider>().bounds.min);
            Debug.Log("Position: " + transform.position);

            if (transform.position.x >= target.GetComponent<CapsuleCollider>().bounds.max.x ||
               transform.position.y >= target.GetComponent<CapsuleCollider>().bounds.max.y ||
               transform.position.z >= target.GetComponent<CapsuleCollider>().bounds.max.z
                )
            {
                transform.rotation = rotation;
                transform.Rotate(Vector3.forward);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else
            {
                Destroy(gameObject);
            }

        }
        else
        {
              Destroy(gameObject);
        }
        //pohyp vpřed ve směru rotace
        //if (transform.position != target.GetComponent<CapsuleCollider>().bounds.max)
        //{
           
        //} else
        //{
        //    transform.rotation = transform.rotation;
        //    transform.position = transform.position;
        //}
           
    }

   
}
