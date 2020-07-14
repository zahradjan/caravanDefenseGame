using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }


    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
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
