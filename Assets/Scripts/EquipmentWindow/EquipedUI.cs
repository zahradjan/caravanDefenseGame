using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedUI : MonoBehaviour
{

    public Transform equipedSlotsParent;

    EquipmentManager equipmentManager;
    CharacterSelector characterSelector;

    EquipedSlot[] eSlots;


    private void Start()
    {
        equipmentManager = characterSelector.selectedCharacter.equipmentManager;
        equipmentManager.onEquipmentChanged += UpdateUI;

        eSlots = equipedSlotsParent.GetComponentsInChildren<EquipedSlot>();

    }

     void UpdateUI(Item newItem, Item oldItem) 
    {
        //equipmentManager = characterSelector.selectedCharacter.equipmentManager;
        if (newItem != null)
        {
            int itemPlace = (int)newItem.equipSlot;
            //Debug.Log("Equiping " + newItem.name + ", itemPlace = " + itemPlace);  
            eSlots[itemPlace].AddItemIcon(newItem);
        }
        else
        {
            eSlots[(int)oldItem.equipSlot].ClearSlot();
        }

    }

    }



