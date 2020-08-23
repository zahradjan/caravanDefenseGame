using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float differenceX ;
    public float differenceY;
    public float differenceZ;
    public GameObject projectilePrefab;
    public  float startDelay;
    private Animator anim;
    public float speed = 20f;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //launch projectile from player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
                Shoot();
            
            
            //Invoke("Shoot", startDelay);
        }


        target = FindClosestEnemy();

    }

    public void Shoot()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + differenceX, transform.position.y + differenceY, transform.position.z + differenceZ);
        if (!TargetIsDead())
        {
            Instantiate(projectilePrefab, spawnPosition, gameObject.transform.rotation);
        }

       
        //Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

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



    private bool TargetIsDead()
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
