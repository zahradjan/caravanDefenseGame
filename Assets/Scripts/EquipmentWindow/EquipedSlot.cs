using UnityEngine;
using UnityEngine.UI;

public class EquipedSlot : InventorySlot
{
    public Sprite defaultSlotIcon;
    public int EquipmentSlotIntex;
    public EquipmentSlot LocalSlot;

    public override void Start()
    {
        slotType = equipedSlotIndex;
        popupWindowObject.SetActive(false);
    }

    public void AddItemIcon(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public override void ClearSlot()
    {
        item = null;
        icon.sprite = defaultSlotIcon;
        removeButton.interactable = false;                 
    }
 


}
