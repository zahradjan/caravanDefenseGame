using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")] //v Unity přibyde možnost create/inventory/item 

public class Item : ScriptableObject{

    new public string name = "New Item";    //název itemu
    public Sprite icon = null;              //ikona itemu
    public bool isDefaultItem = false;
}
