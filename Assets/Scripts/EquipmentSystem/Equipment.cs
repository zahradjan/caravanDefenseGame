using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create/inventory/Equipment
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")] 

public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    //stats
    public int armorModifier;
    public int damageModifier;

    public override void Use() //equip item
    {
        base.Use();
        EquipmentManager.instance.Equip(this); 
        RemoveFromInventory();                  
    }

}

public enum EquipmentSlot{ Head, Chest, Hands, Legs, Feet, Weapon, Offhand }