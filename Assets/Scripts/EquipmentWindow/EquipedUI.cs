using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedUI : MonoBehaviour
{

    public Transform equipedSlotsParent;
    public GameObject gameManager;
    EquipmentManager equipmentManager;
    CharacterSelector characterSelector;

    EquipedSlot[] eSlots;


    private void Start()
    {
        equipmentManager = gameManager.GetComponent<EquipmentManager>();
        //equipmentManager = characterSelector.selectedCharacter.equipmentManager;
        equipmentManager.onEquipmentChanged += UpdateUI;

        eSlots = equipedSlotsParent.GetComponentsInChildren<EquipedSlot>();

    }

    public  void UpdateUI(Item newItem, Item oldItem) 
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

    public void RemoveOldIcons()
    {
        for (int i = 0; i < eSlots.Length; i++)
        {
            if (eSlots[i] != null)
            {

                eSlots[i].ClearSlot();
                //Debug.Log("removed old equip icons!");
            }
        }
    }

    public void InvokeCurrentIcons()
    { 
        for (int i = 0; i < eSlots.Length; i++)
        {
                Item newItem = equipmentManager.currentEquipment[i];
                if (newItem != null)
                {
                    int itemPlace = (int)newItem.equipSlot;
                    eSlots[itemPlace].AddItemIcon(newItem);
                }
                else
                {
                    eSlots[i].ClearSlot();
                }
        }
    }
    


}



