using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")] //create/inventory/item 

public class Item : ScriptableObject{

    new public string name = "New Item";    //název itemu
    public Sprite icon = null;              //ikona itemu
    public bool isDefaultItem = false;

    public virtual void Use ()
    {
        //use the item
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}
