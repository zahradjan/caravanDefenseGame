using UnityEngine;
using UnityEngine.UI;

public class EquipedSlot : InventorySlot
{
    //public Image icon;

    //Item item;
    //public Button removeButton;
    public Sprite defaultSlotIcon;
    public int EquipmentSlotIntex;
    public EquipmentSlot LocalSlot;


    public void AddItemIcon(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    /*public void ClearSlot()
    {
        item = null;
        icon.sprite = defaultSlotIcon;
        removeButton.interactable = false;
    }*/
 


}
