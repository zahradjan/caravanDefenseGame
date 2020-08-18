using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    public GameObject inventorySlot;
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
        UpdateInfoWindow(); 
    }

    // Update is called once per frame
    void UpdateInfoWindow()
    {
        itemName = GameObject.Find("ItemName").GetComponent<Text>();
        //itemName.text = " " + inventorySlot.GetComponent<Item>().name;

        itemDamage = GameObject.Find("ItemDamage").GetComponent<Text>();
       // itemDamage.text = " " + inventorySlot.GetComponent<Equipment>().armorModifier;
    }
}
