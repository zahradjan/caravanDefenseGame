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

     void UpdateUI(Item newItem, Item oldItem) 
    {
        if (newItem != null)
        {
            int itemPlace = (int)newItem.equipSlot;
            Debug.Log("Equiping " + newItem.name + ", itemPlace = " + itemPlace);  

            eSlots[itemPlace].AddItemIcon(newItem);
        }
        else
        {
            eSlots[(int)oldItem.equipSlot].ClearSlot();
        }

    }

    }



