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
        // hit ktery dostava i kdyz ten nepritel spadne k zemi je proto ze kollidery toho nepritele se vypnou protoze je mrtvej
        // => cili ta podminka se provede problem je ze collidery toho zivyho furt detekuji kolizi a tim padem ten hit z toho
        // padu detekuji a proto se ty zivoty uberou :)
        if (anim.GetBool("isDead") == true) return;


        //Debug.Log("My layer: " + gameObject.layer);
        //Debug.Log("Opponents layer: " + other.gameObject.layer);
        //Debug.Log("My tag: " + gameObject.tag);
        //Debug.Log("Opponents tag: " + other.gameObject.tag);


        
            DealDamage();

       
    


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
        if (currentHealth <= 0)
        {
            Die();
        }
    }
        
    int GetCurrentHealth()
    {
        return currentHealth;
    }

    void DealDamage()
    {
      
        currentHealth -= 20;
        healthBar.SetHealth(currentHealth);
        //Debug.Log("currentHealth: " + currentHealth);
    }
    void Die()
    {
            // tady jsem skoncil takhle neprovadet on se pri kazdem updatu bude hazet do ty vrstvy a bude se to furt provolavat
            anim.SetBool("isDead", true);
        if (gameObject.layer != 11)
        {
            gameObject.layer = LayerMask.NameToLayer("Hell");
            transform.Find("Armature/ik_wrist_right/Capsule").gameObject.layer = LayerMask.NameToLayer("Hell");
          
        }
       
      
        }
}
