using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Button RemoveButton;

    public void Start()
    {
        RemoveButton = GetComponent<Button>();
        
    }

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        //Debug.Log(RemoveButton.name);
        //RemoveButton.interactable = true;
        
    }

    public void ClearSlot(Item newItem)
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
       // RemoveButton.interactable = false;
    }
}
