using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour {

    public Image icon;
    public Item item;
    public Button clickButton;

    void Start()
    {
        icon.sprite = item.icon;
        clickButton.onClick.AddListener(PickUp);
    }

     private void PickUp()
     {
            //Debug.Log("Picking up " + item.name);
            Inventory.instance.Add(item);
            Destroy(gameObject);

     }

    void TakeAll()
    {
        //on button click - Loot All
    }
}

