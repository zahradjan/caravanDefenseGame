using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")] //create/inventory/item 

public class Item : ScriptableObject{
    //basic item stuff
    new public string name = "New Item";    
    public Sprite icon = null;              
    public bool isDefaultItem = false;
    public bool isJustResources;
    public bool isEquipment;
    public int resourcesValue;

    //Equipment stuff
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    //stats
    public int armorModifier;
    public int damageModifier;
    public int healthModifier;
    public int attackSpeedModifier;
    public int movementSpeedModifier;
    public int spiritPowerModifier;


    


    public virtual void Use ()
    {
        //Debug.Log("Using " + name);
       

        if (isJustResources == true)
        {
            Resources.instance.AddResources(resourcesValue);
            //RemoveFromInventory();
        }

        if (isEquipment == true)
        {
            EquipmentManager.instance.Equip(this);
            RemoveFromInventory();
        }
    }

    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}
public enum EquipmentSlot { Head, Chest, Hands, Legs, Feet, Weapon, Offhand, Consumable}
