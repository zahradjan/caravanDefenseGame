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
    public string opponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != opponent) return;

        if (anim.GetBool("isAttacking") == true)
        {
            Debug.Log("Hit!");

            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            Debug.Log("currentHealth: " + currentHealth);
            if (currentHealth <= 0)
            {
                anim.SetBool("isDead", true);
            }
            else
            {
                anim.SetBool("isDead", false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int GetCurrentHealth()
    {
        return currentHealth;
    }
}
