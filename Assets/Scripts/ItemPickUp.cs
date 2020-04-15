using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour {

    public Item item;
    public Button clickButton;

    void Start()
    {
       clickButton.onClick.AddListener(PickUp);

    }


    void Update()
    {
        
    }

     private void PickUp()
     {


       // if(Input.GetMouseButtonDown(0))
      //  {
            Debug.Log("Picking up " + item.name);
            //add to inventory
            Inventory.instance.Add(item);
            Destroy(gameObject);

       // }
       


     }
}

