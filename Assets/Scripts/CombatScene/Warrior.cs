using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(menuName = "Warrior")]
public class Warrior : WarriorBase
{
    public string characterName = "New Character";
    EquipmentManager equipmentManager;
    CharacterSkills characterSkills;

    public GameObject basicModel;
    public GameObject equipedModel;
    public Vector3 hitboxSize;
    public Vector3 offset;

    //characterStats
    [HideInInspector] public Vector3 characterHeight;
    [HideInInspector] private float heightModifier = 1.05f;

    public int characterLevel;
    [HideInInspector] public Stat statPoints;
    [HideInInspector] public Stat maxHealth;
    [HideInInspector] public int currentHealth { get; private set; }
    public Stat damage;
    public Stat armor;
    [HideInInspector] public Stat attackSpeed;
    [HideInInspector] public Stat movementSpeed;
    [HideInInspector] public Stat spiritPower;
    //main stats
    [HideInInspector] public Stat strength;
    [HideInInspector] public Stat agility;
    [HideInInspector] public Stat wisdom;

    [Tooltip("0 head, 1 chest, 2 hands, 3 legs, 4 feet, 5 weapon, 6 offhand")]
    public Item[] currentEquipment;


    private void Awake()
    {
        //hold instance of CharacterSkills
        characterSkills = new CharacterSkills();
        equipmentManager = new EquipmentManager();

        //Equipment
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Item[numSlots];

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

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDmg()
    {
        throw new System.NotImplementedException();
    }

    public override void SetDefaultBaseStats()
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
}