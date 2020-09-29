using UnityEngine;
using UnityEngine.UI;

public class LootSlot: InventorySlot {
    public Button clickButton;
    Inventory inventory;
   

    public override void Start()
    {
        slotType = lootSlotIndex;
        inventory = Inventory.instance;
        icon.sprite = item.icon;
        clickButton.onClick.AddListener(PickUp);
        //popupWindowObject.SetActive(false);
        removeButton.interactable = true;
    }

    private void PickUp()
    {
        if (inventory.items.Count < inventory.space)
        {
            Inventory.instance.Add(item);
            Destroy(gameObject);
            ItemInfoUI itemInfoUI = gameObject.GetComponent<ItemInfoUI>();
            GameObject popUpWindow = itemInfoUI.popupWindowObject;
            itemInfoUI.popupWindowObject.SetActive(false);
            //Debug.Log("Picking up " + item.name);
            //Debug.Log("inventory.items.count = " + inventory.items.Count);
        }
    }
   
    void TakeAll()
    {
        //on button click - Loot All
    }
}

