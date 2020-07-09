using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 200; // později "int" předělat na "Stat" aby se s tím dalo pracovat
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

     void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(40);
        }
    }

    public void TakeDamage (int damage)
    {
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); //prevents damage from going to negative numbers

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " Died.");
    }


}
