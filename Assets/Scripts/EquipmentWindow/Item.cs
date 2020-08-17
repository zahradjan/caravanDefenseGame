using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")] //create/inventory/item 

public class Item : ScriptableObject{

    new public string name = "New Item";    
    public Sprite icon = null;              
    public bool isDefaultItem = false;
    public bool isJustResources;
    public int resourcesValue;


    public virtual void Use ()
    {
        Debug.Log("Using " + name);
        //override in Equipment.cs

        if (isJustResources == true)
        {
            Resources.instance.AddResources(resourcesValue);
            //RemoveFromInventory();
        }
        
    }

    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}
