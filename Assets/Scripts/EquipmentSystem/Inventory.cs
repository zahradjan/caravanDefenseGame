using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{

    #region Singleton    
    public static Inventory instance; 

    void Awake()    
    {
        if (instance != null) //just warning
        {
            Debug.LogWarning("More then one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 36; //capacity

    public List<Item> items = new List<Item>(); 

    public void Add (Item item)
    {
        if(!item.isDefaultItem) //ADD ITEM
        {
            if (items.Count >= space) //capacity
            {
                Debug.Log("Not enough room."); 
                return;
            }

            items.Add(item);

            if(onItemChangedCallBack != null){
                onItemChangedCallBack.Invoke(); 
            }
        }

    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null){
            onItemChangedCallBack.Invoke(); 
        }
    }

}
