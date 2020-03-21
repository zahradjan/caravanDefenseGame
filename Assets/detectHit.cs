using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class detectHit : MonoBehaviour
{

   // public Slider healthBar;
    public HealthBar healthBar;
    Animator anim;
    private int maxHealth = 100;
    private int currentHealth; 

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Hit!");

        currentHealth -= 10;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
        }
        else
        {
            anim.SetBool("isDead", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar = GetComponent<Slider>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
