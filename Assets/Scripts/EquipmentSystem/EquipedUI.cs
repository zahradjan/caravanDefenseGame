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

     void UpdateUI(Equipment newItem, Equipment oldItem) 
    {
        

        //Projet všechny sloty, pokud "itemPlace" itemu se rovná "LocalSlot" EquipedSlotu, použít ikonu, else - nechat slot prázdný
        for (int i = 0; i < eSlots.Length; i++)  
        {
            Debug.Log("Updating Equipment UI");


            //int localIndex = System.Enum.GetNames(typeof(EquipmentSlot)).Length; //určí jen celkový počet, to je kničemu
         

            // int localIndex = (int)LocalSlot;  //potřebuju konkrétní LocalSlot z EquipedSlot





            if (newItem != null) // pokud není tahle podmínka,  "itemPlace" způsobí bug při unequipu
            {
                // int localIndex = (int)LocalSlot;  //potřebuju  LocalSlot z konkrétního EquipedSlot

                int itemPlace = (int)newItem.equipSlot; //tohle funguje správně - určí kam item patří
                Debug.Log("Equiping " + newItem.name + ", itemPlace = " + itemPlace);  // potvrzuje že itemPlace udává správnou hodnotu
            }



            /* if (localIndex == itemPlace) //následně porovnává podle hodnot jestli item patří na tohle místo nebo ne
             {

                 Debug.Log("localIndex= " + localIndex + "itemPlace = " + itemPlace);
                 eSlots[i].AddItem(Item newItem); //=přidat item
             }
             else
             {
                 Debug.Log("NOPE" + "localIndex= " + localIndex + "itemPlace = " + itemPlace);
                 // eSlots[i].ClearSlot(); //=nechat slot prázdný
             }
             */


        }

    }


}
