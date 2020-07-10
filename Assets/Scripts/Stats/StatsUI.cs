using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    EquipmentManager equipmentManager;

    public GameObject selectedCharacter;
    Text armorUI;
    Text damageUI;

    private void Start()
    {
      /*  equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChanged += UpdateStatsUI;*/
    }

    private void Update()
    {
        UpdateStatsUI(selectedCharacter); // předělat aby se updatenulo jen když se změní equip - equipmentManager.onEquipmentChanged
    }


    public void UpdateStatsUI(GameObject selectedCharacter)
    {
        armorUI = GameObject.Find("TextArmor").GetComponent<Text>();
        armorUI.text = "Armor: " + selectedCharacter.GetComponent<PlayerStats>().armor.getValue();

        damageUI = GameObject.Find("TextDamage").GetComponent<Text>();
        damageUI.text = "Damage: " + selectedCharacter.GetComponent<PlayerStats>().damage.getValue();


        /*
        // or you can also do this
        string example = "Hello2";
        armorUI.text = example;
        */
    }

    
}
