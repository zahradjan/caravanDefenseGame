using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    // EquipmentManager equipmentManager;
    CharacterSelector characterSelector;
    Resources resources;

    
    Text characterName;
    Text levelUI;
    Text healthUI;
    Text armorUI;
    Text damageUI;
    Text strengthUI;
    Text agilityUI;
    Text wisdomUI;
    Text resourcesUI;
    

    private void Start()
    {
        // EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        characterSelector = CharacterSelector.instance;
        resources = Resources.instance;
    }

    private void Update()
    {
        UpdateStatsUI(); 


    }


    public void UpdateStatsUI()
    {
        Debug.Log("StatsUI Updated" + characterSelector.selectedCharacter.characterName); //nefunguje
        levelUI = GameObject.Find("TextName").GetComponent<Text>();
        levelUI.text = " " + characterSelector.selectedCharacter.characterName;
        Debug.Log("StatsUI confirms: Selected Character's name is " + characterSelector.selectedCharacter.characterName); //nefunguje

        levelUI = GameObject.Find("TextLvl").GetComponent<Text>();
        levelUI.text = "Level: " + characterSelector.selectedCharacter.characterLevel;

        healthUI = GameObject.Find("TextHealth").GetComponent<Text>();
        healthUI.text = "Health: " + characterSelector.selectedCharacter.maxHealth.getValue();

        armorUI = GameObject.Find("TextArmor").GetComponent<Text>();
        armorUI.text = "Armor: " + characterSelector.selectedCharacter.armor.getValue();

        damageUI = GameObject.Find("TextDamage").GetComponent<Text>();
        damageUI.text = "Damage: " + characterSelector.selectedCharacter.damage.getValue();

        damageUI = GameObject.Find("TextAttackSpeed").GetComponent<Text>();
        damageUI.text = "Attack Speed: " + characterSelector.selectedCharacter.attackSpeed.getValue();

        damageUI = GameObject.Find("TextMovementSpeed").GetComponent<Text>();
        damageUI.text = "Movement Speed: " + characterSelector.selectedCharacter.movementSpeed.getValue();

        damageUI = GameObject.Find("TextSpiritPower").GetComponent<Text>();
        damageUI.text = "Spirit Power: " + characterSelector.selectedCharacter.spiritPower.getValue();

        strengthUI = GameObject.Find("TextStatPoints").GetComponent<Text>();
        strengthUI.text = "Unused Stat Points: " + characterSelector.selectedCharacter.statPoints.getValue();

        strengthUI = GameObject.Find("TextStrength").GetComponent<Text>();
        strengthUI.text = "Strength: " + characterSelector.selectedCharacter.strength.getValue();

        agilityUI = GameObject.Find("TextAgility").GetComponent<Text>();
        agilityUI.text = "Agility: " + characterSelector.selectedCharacter.agility.getValue();

        wisdomUI = GameObject.Find("TextWisdom").GetComponent<Text>();
        wisdomUI.text = "Wisdom: " + characterSelector.selectedCharacter.wisdom.getValue();

        resourcesUI = GameObject.Find("TextResources").GetComponent<Text>();
        resourcesUI.text = "Resources: " + resources.currentResources;
        resourcesUI = GameObject.Find("TextResources2").GetComponent<Text>();
        resourcesUI.text = "Resources: " + resources.currentResources;

        //dissable buttons
        /*  if (PlayerStats.statPoints.getValue() > 0)
          {
              strengthButton.interactable = true;
              agilityButton.interactable = true;
              wisdomButton.interactable = true;
          }
          else
          {
              strengthButton.interactable = false;
              agilityButton.interactable = false;
              wisdomButton.interactable = false;
          }*/



    }


}
