using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour {

    public Item item;
    public Button clickButton;

    void Start()
    {
       clickButton.onClick.AddListener(PickUp);
    }

     private void PickUp()
     {
            Debug.Log("Picking up " + item.name);
            Inventory.instance.Add(item);
            Destroy(gameObject);

     }
}

