using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedUI : MonoBehaviour
{
    /*public GameObject headSlot;
    public GameObject chestSlot;
    public GameObject handSlot;
    public GameObject legsSlot;
    public GameObject feetSlot;
    public GameObject weaponSlot;
    public GameObject offhandSlot;*/

   

    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChange;

    }

     void OnEquipmentChange(Equipment newItem, Equipment oldItem)
    {
        UpdateUI();
    }


     void UpdateUI()
    {
        Debug.Log("Updating Equipment UI");
        
    }
}
