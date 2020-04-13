using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickUp : MonoBehaviour {

    public Item item;

    void Update()
    {
        PickUp();
    }

     private void PickUp()
     {


        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Picking up " + item.name);
            //add to inventory
            Inventory.instance.Add(item);
            Destroy(gameObject);

        }
       


     }
}

