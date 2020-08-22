using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    public float speed = 20f;
    private Transform target;
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    // Start is called before the first frame update
    void Start()
    {
        //najde cíl
        //target = FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {

        target = FindClosestEnemy();
        //nastaví rotaci
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
       
        Debug.Log("Bounds min: " + target.GetComponent<CapsuleCollider>().bounds.min);
        Debug.Log("Position: " + transform.position);

        if(transform.position.x >= target.GetComponent<CapsuleCollider>().bounds.max.x || 
           transform.position.y >= target.GetComponent<CapsuleCollider>().bounds.max.y ||
           transform.position.z >= target.GetComponent<CapsuleCollider>().bounds.max.z
            )
        {
            transform.rotation = rotation;
            transform.Rotate(Vector3.forward);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
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
}
