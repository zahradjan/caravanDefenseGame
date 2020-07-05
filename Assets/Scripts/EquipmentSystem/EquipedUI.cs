using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedUI : MonoBehaviour
{
 
    public Transform equipedSlotsParent;

    EquipmentManager equipmentManager;

    EquipedSlot[] eSlots;


    private void Start()
    {
        equipmentManager = EquipmentManager.instance;

        equipmentManager.onEquipmentChanged += UpdateUI;

        eSlots = equipedSlotsParent.GetComponentsInChildren<EquipedSlot>();

    }

     void UpdateUI(Equipment newItem, Equipment oldItem) // odkázat se na equip() a unequip() v EquipmentManager.cs
    {
        Debug.Log("Updating Equipment UI");

        //Projet všechny sloty, pokud "slotIndex" itemu se rovná "LocalSlot" EquipedSlotu, použít ikonu, else - nechat slot prázdný
        for (int i = 0; i < eSlots.Length; i++)  
        {
            if (true) 
            {
                
            }
            else
            {
               // eSlots[i].ClearSlot();
            }
        }

    }


}
