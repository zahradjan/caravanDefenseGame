using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{


    //udělá že může existovat pouze jedna instance inventáře (pouze jeden inventář)
    #region Singleton    
    public static Inventory instance; 

    void Awake()    
    {
        if (instance != null) //je jen varování
        {
            Debug.LogWarning("More then one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();       //nevim přesně co dělá tohle ale je to důležitý pro UI :D
    public OnItemChanged onItemChangedCallBack;

    public int space = 36; //(zatím) maximální kapacita inventáře

    public List<Item> items = new List<Item>(); //list itemů

    public void Add (Item item)
    {
        if(!item.isDefaultItem) //PŘIDAT ITEM
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room."); //překročena kapacita inventáře (tutoriál pokračuje E04 11:00)
                return;
            }

            items.Add(item);

            if(onItemChangedCallBack != null){
                onItemChangedCallBack.Invoke(); //triggering event, taky důležitý
            }
        }

    }

    public void Remove(Item item) //ODEBRAT ITEM
    {
        items.Remove(item);

        if (onItemChangedCallBack != null){
            onItemChangedCallBack.Invoke(); //triggering event, taky důležitý
        }
    }

}
