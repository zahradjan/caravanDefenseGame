using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    public InventorySlot inventorySlot;
    Text itemName;
    Text itemDamage;
    Text itemArmor;
    Text itemValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() //make it onItemChangedCallBack
    {
        if (inventorySlot.item != null)
        {
            UpdateInfoWindow();
        }
        
    }

    // Update is called once per frame
    void UpdateInfoWindow()
    {
        itemDamage = GameObject.Find("ItemDamage").GetComponent<Text>();
        itemArmor = GameObject.Find("ItemArmor").GetComponent<Text>();


        itemName = GameObject.Find("ItemName").GetComponent<Text>();
        itemName.text = inventorySlot.item.name;

        itemValue = GameObject.Find("ItemValue").GetComponent<Text>();
        itemValue.text = "O Value: " + inventorySlot.item.resourcesValue;

        if (inventorySlot.item.damageModifier != 0)
        {
            itemDamage.text = "Damage: " + inventorySlot.item.damageModifier;
            itemArmor.text = " "; //solution for now
        }
        else
        {
            itemDamage.text = " ";
        }

        if (inventorySlot.item.armorModifier != 0)
        {
            itemArmor.text = "Armor: " + inventorySlot.item.armorModifier;
            itemDamage.text = " ";
        }
        else
        {
            itemArmor.text = " ";
        }

    }
}
