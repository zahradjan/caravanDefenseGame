﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float differenceX ;
    public float differenceY;
    public GameObject projectilePrefab;
    public  float startDelay;
    private Animator anim;

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
    }

    void Shoot()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + differenceX, transform.position.y + differenceY, transform.position.z);
        Instantiate(projectilePrefab, spawnPosition, gameObject.transform.rotation);
    }
}