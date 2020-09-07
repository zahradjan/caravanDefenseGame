using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{

    public string characterName = "New Character";
    CharacterStats characterStats;
    public EquipmentManager equipmentManager;
    CharacterSkills characterSkills;

    //characterStats
    public Vector3 characterHeight;
    private float heightModifier = 1.05f;

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

    //EquipmentManager
    public Item[] currentEquipment;
    //public SkinnedMeshRenderer[] currentMeshes;

    private void Awake()
    {
        //hold instance of CharacterSkills
        characterSkills = new CharacterSkills();
        equipmentManager = new EquipmentManager();
        


        //PlayerStats (- původně ve void start, ne ve void Awake)
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        //Equipment
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Item[numSlots];
        //currentMeshes = new SkinnedMeshRenderer[numSlots];

       
    }


    public bool CanUseHeavyAttack()
    {
        return characterSkills.isSkillUnlocked(CharacterSkills.Skill.HeavyAttack);
    }
    public bool CanUseSnipeShot()
    {
        return characterSkills.isSkillUnlocked(CharacterSkills.Skill.SnipeShot);
    }
    public bool CanUseHeal()
    {
        return characterSkills.isSkillUnlocked(CharacterSkills.Skill.Heal);
    }

    public CharacterSkills GetCharacterSkills()
    {
        return characterSkills;
    }


  //characterStats
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

    public void TakeDamage(int dmg)
    {
        dmg -= armor.getValue();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue); //prevents dmg from going to negative numbers

        currentHealth -= dmg;
        Debug.Log(characterName + " takes " + dmg + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way
        // This method is meant to be overwritten
        Debug.Log(characterName + " Died.");
    }

    public void SetDefaultBaseStats()
    {
        characterHeight = new Vector3(1f, 1f, 1f);
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

    public void LevelUp()
    {
        int levelCost = (characterLevel * 250) / 2; //make some better cost per lvl calculation
        int resources = Resources.instance.currentResources;

        if (resources > 0 && resources >= levelCost)
        {
            Resources.instance.AddResources(-levelCost);
            characterLevel += 1;
            statPoints.AddModifier(1);
            Debug.Log(characterName + " Leveled Up! " + characterName + "'s level is now " + characterLevel);
            Debug.Log("Cost per lvl = " + levelCost);
        }

    }

    public void IncreaseStat(Stat stat) //for buttons
    {
        statPoints.RemoveModifier(1);
        stat.AddModifier(1);

    }
    #region Increase Stat
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
    #endregion

    public void OnStrengthStatUp()
    {
        maxHealth.AddModifier(5);
        characterHeight *= heightModifier;
        //transform.localScale = characterHeight; //dořešit
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
        //lower cooldown?
    }
    
   
    void OnEquipmentChanged(Item newItem, Item oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
            maxHealth.AddModifier(newItem.healthModifier);
            attackSpeed.AddModifier(newItem.attackSpeedModifier);
            movementSpeed.AddModifier(newItem.movementSpeedModifier);
            spiritPower.AddModifier(newItem.spiritPowerModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            maxHealth.RemoveModifier(oldItem.healthModifier);
            attackSpeed.RemoveModifier(oldItem.attackSpeedModifier);
            movementSpeed.RemoveModifier(oldItem.movementSpeedModifier);
            spiritPower.RemoveModifier(oldItem.spiritPowerModifier);
        }

    }

}