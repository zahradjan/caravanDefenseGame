using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Button removeButton;

  
    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        
    }

    public void ClearSlot(Item newItem) //nedaří se zavolat tuhle funkci v InventoryUI.cs
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        Debug.Log("Clear Slot"); 
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
        Debug.Log(item.name + " removed from Inventory!");
    }

    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
