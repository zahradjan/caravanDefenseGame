using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI() //updatuje inventář, to else má asi prázdný místa označit jako prázdný místa - "vynullovat" je (viz. InventorySlot.cs/ClearSlot) (4:50 E06)
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
          /*  else
            {
              slots[i].ClearSlot();  //z nějakýho důvodu způsobuje error a nefunguje 
            }*/
        }
    }
}
