using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject ItemInfoWindow;

    Inventory inventory;

    InventorySlot[] slots;

   
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        ItemInfoWindow.SetActive(false);
    }

    void UpdateUI() 
    {
        //Debug.Log("Updating Inventory UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
              slots[i].ClearSlot();  
            }
        }
    }
}
