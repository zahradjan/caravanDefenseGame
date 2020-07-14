using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    EquipmentManager equipmentManager;

    public GameObject selectedCharacter;
    Text levelUI;
    Text healthUI;
    Text armorUI;
    Text damageUI;
    Text strengthUI;
    Text agilityUI;
    Text wisdomUI;

    private void Start()
    {
       // EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    private void Update()
    {
        UpdateStatsUI(selectedCharacter); 
    }


    public void UpdateStatsUI(GameObject selectedCharacter)
    {
        levelUI = GameObject.Find("TextLvl").GetComponent<Text>();
        levelUI.text = "Level: " + selectedCharacter.GetComponent<PlayerStats>().characterLevel;

        healthUI = GameObject.Find("TextHealth").GetComponent<Text>();
        healthUI.text = "Health: " + selectedCharacter.GetComponent<PlayerStats>().maxHealth.getValue();

        armorUI = GameObject.Find("TextArmor").GetComponent<Text>();
        armorUI.text = "Armor: " + selectedCharacter.GetComponent<PlayerStats>().armor.getValue();

        damageUI = GameObject.Find("TextDamage").GetComponent<Text>();
        damageUI.text = "Damage: " + selectedCharacter.GetComponent<PlayerStats>().damage.getValue();

        strengthUI = GameObject.Find("TextStatPoints").GetComponent<Text>();
        strengthUI.text = "Unused Stat Points: " + selectedCharacter.GetComponent<PlayerStats>().statPoints.getValue();

        strengthUI = GameObject.Find("TextStrength").GetComponent<Text>();
        strengthUI.text = "Strength: " + selectedCharacter.GetComponent<PlayerStats>().strength.getValue();

        agilityUI = GameObject.Find("TextAgility").GetComponent<Text>();
        agilityUI.text = "Agility: " + selectedCharacter.GetComponent<PlayerStats>().agility.getValue();

        wisdomUI = GameObject.Find("TextWisdom").GetComponent<Text>();
        wisdomUI.text = "Wisdom: " + selectedCharacter.GetComponent<PlayerStats>().wisdom.getValue();


        /*
        // or you can also do this
        string example = "Hello2";
        armorUI.text = example;
        */
    }

    
}
