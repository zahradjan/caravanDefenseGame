using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour {
    public Image icon;
    public Item item;
    public Button clickButton;
    Inventory inventory;
   

    void Start()
    {
        inventory = Inventory.instance;
        icon.sprite = item.icon;
        clickButton.onClick.AddListener(PickUp);
    }

    private void PickUp()
    {
        if (inventory.items.Count < inventory.space)
        {
            Inventory.instance.Add(item);
            Destroy(gameObject);
            //Debug.Log("Picking up " + item.name);
            Debug.Log("inventory.items.count = " + inventory.items.Count);
        }
    }

    void TakeAll()
    {
        //on button click - Loot All
    }
}

