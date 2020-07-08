using UnityEngine;
using UnityEngine.UI;

public class EquipedSlot : MonoBehaviour
{
    public Image icon;
    public Sprite defaultSlotIcon;
    Item item;
    public Button removeButton;
    public int EquipmentSlotIntex;
    public EquipmentSlot LocalSlot;


    public void AddItemIcon(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        //Debug.Log(item.name + " removed from Inventory!");
       // Inventory.instance.Remove(item);
    }

    /*public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }*/
}
