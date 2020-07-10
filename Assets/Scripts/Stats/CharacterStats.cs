using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int CharacterLevel;

    public int maxHealth = 200; // později "int" předělat na "Stat" aby se s tím dalo pracovat
    public int currentHealth { get; private set; }

    public Stat damage; 
    public Stat armor;

    public Stat Strength;
    public Stat Agility;
    public Stat Intelect;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // TESTING
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(40);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LevelUp();
        }
    }

    public void TakeDamage (int dmg)
    {
        dmg -= armor.getValue();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue); //prevents dmg from going to negative numbers

        currentHealth -= dmg;
        Debug.Log(transform.name + " takes " + dmg + " damage.");

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

    public void LevelUp()
    {
        CharacterLevel += 1;
        Debug.Log(transform.name + " Leveled Up! " + transform.name + "'s level is now " + CharacterLevel);
    }
}
