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
    private int randomDamage;
    private int dmg_high;
    private int dmg_low;

    private void OnTriggerEnter(Collider other)
    {
        // hit ktery dostava i kdyz ten nepritel spadne k zemi je proto ze kollidery toho nepritele se vypnou protoze je mrtvej
        // => cili ta podminka se provede problem je ze collidery toho zivyho furt detekuji kolizi a tim padem ten hit z toho
        // padu detekuji a proto se ty zivoty uberou :)
        //if (anim.GetBool("isDead") == true) return;

        //if (other.tag == transform.tag) return;


        //Debug.Log("My layer: " + gameObject.layer);
        //Debug.Log("Opponents layer: " + other.gameObject.layer);
        //Debug.Log("My tag: " + gameObject.tag);
        //Debug.Log("Opponents tag: " + other.gameObject.tag);
        if(other.tag != transform.tag && anim.GetBool("isDead") == false)
        {
            DealDamage();
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
        if (MyTimeHasCome())
        {
            Die();
        }
    }

    private bool MyTimeHasCome()
    {
        return currentHealth <= 0 && gameObject.layer != 11;
    }

    int GetCurrentHealth()
    {
        return currentHealth;
    }

    void DealDamage()
    {
        randomDamage = Random.Range(0, 5);
       
        dmg_high  = (20 + randomDamage);
        dmg_low =  (20 - randomDamage);
        currentHealth -= Random.Range(dmg_low, dmg_high);

        healthBar.SetHealth(currentHealth);
        Debug.Log("currentHealth: " + currentHealth);
    }
    void Die()
    {
     
      
        
       
            Debug.Log("Umrel jsem!");
            anim.SetBool("isAttacking", false);
            anim.SetBool("isDead", true);
            gameObject.layer = LayerMask.NameToLayer("Hell");
            
            transform.Find("HealthBar").gameObject.SetActive(false);
            transform.Find("Armature/ik_wrist_right/right_hand/weapon_bone/Collider").gameObject.SetActive(false);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
       
        


    }
}
