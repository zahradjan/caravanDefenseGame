using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    Item item;
    public Button removeButton;
    public GameObject popupWindowObject;

    public void Start()
    {
        popupWindowObject.SetActive(false);
    }


    public void AddItem (Item newItem)
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
        Debug.Log(item.name + " removed from Inventory!");
        Inventory.instance.Remove(item);
    }

    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            popupWindowObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null)
        {
            popupWindowObject.SetActive(false);
        }
    }



}
