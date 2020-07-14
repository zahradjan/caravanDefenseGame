using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int characterLevel;
    public Stat statPoints;
    public Stat maxHealth;
    public int currentHealth { get; private set; }
    public Stat damage; 
    public Stat armor;
    public Stat attackSpeed;
    public Stat movementSpeed;
    public Stat spiritPower;

    public Stat strength;
    public Stat agility;
    public Stat wisdom;

    //public delegate void OnstatsUpdated();
   // public OnstatsUpdated onstatsUpdated;

    void Awake()
    {
        maxHealth.SetBaseValue(100);
        currentHealth = maxHealth.getValue();
        characterLevel = 1;
        //set the minimum of main stats to 1 instead of 0
        strength.SetBaseValue(1);
        agility.SetBaseValue(1);
        wisdom.SetBaseValue(1);
        attackSpeed.SetBaseValue(10);
        movementSpeed.SetBaseValue(10);
        damage.SetBaseValue(10);

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

      /*  if (onstatsUpdated != null)
        {
            onstatsUpdated.Invoke();
        }*/
    }

    public void IncreaseStat(Stat stat) //for buttons
    {
            statPoints.RemoveModifier(1);
            stat.AddModifier(1);
    }
    
    public void IncreaseStrength()
    {
        if (statPoints.getValue() > 0)
        {
            IncreaseStat(strength);
            OnStrengthStatUp();
        }
        
    }
    public void IncreaseAgility()
    {
        if (statPoints.getValue() > 0)
        {
            IncreaseStat(agility);
            OnAgilityStatUp();
        }
        
    }
    public void IncreaseWisdom()
    {
        if (statPoints.getValue() > 0)
        {
            IncreaseStat(wisdom);
            OnWisdomStatUp();
        }
        
    }

    public void OnStrengthStatUp()
    {
        maxHealth.AddModifier(5);
        //+increase character model size
    }
    public void OnAgilityStatUp()
    {
        attackSpeed.AddModifier(2);
        movementSpeed.AddModifier(2);
    }
    public void OnWisdomStatUp()
    {
        spiritPower.AddModifier(2);
        //cooldown?
    }
}
