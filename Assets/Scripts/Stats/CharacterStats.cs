using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int characterLevel;
    public Stat statPoints;
    public Stat maxHealth;
    public int currentHealth { get; private set; }
    public Stat damage; 
    public Stat armor;

    public Stat strength;
    public Stat agility;
    public Stat wisdom;

    void Awake()
    {
        maxHealth.SetBaseValue(100);
        currentHealth = maxHealth.getValue();
        characterLevel = 1;
        //set the minimum of main stats to 1 instead of 0
        strength.SetBaseValue(1);
        agility.SetBaseValue(1);
        wisdom.SetBaseValue(1);

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
        characterLevel += 1;
        statPoints.AddModifier(1);
        Debug.Log(transform.name + " Leveled Up! " + transform.name + "'s level is now " + characterLevel);
        Debug.Log("Stat points = " + statPoints.getValue());
    }

    public void IncreaseStat(Stat stat)
    {
        statPoints.RemoveModifier(1);
        stat.AddModifier(1);
    }
}
