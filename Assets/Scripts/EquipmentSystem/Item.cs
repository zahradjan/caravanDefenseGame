using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")] //create/inventory/item 

public class Item : ScriptableObject{

    new public string name = "New Item";    
    public Sprite icon = null;              
    public bool isDefaultItem = false;

    public virtual void Use ()
    {
        //use the item (also works for other items then equipment like consumables or something)
        Debug.Log("Using " + name);
        //override in Equipment.cs
    }

    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}
