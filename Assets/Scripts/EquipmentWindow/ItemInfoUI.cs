using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInfoUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InventorySlot thisSlot;
    Text itemName;
    Text itemDamage;
    Text itemArmor;
    Text itemValue;
    public GameObject popupWindowObject;
    RectTransform thisSlotTransform;
    RectTransform popupWindowTransform;
    Vector3 difference = new Vector3(115, 110);

    // Start is called before the first frame update
    void Start()
    {
        popupWindowObject = GameObject.Find("ItemInfoPanel");
        thisSlotTransform = GetComponent<RectTransform>();
        popupWindowTransform = popupWindowObject.GetComponent<RectTransform>();     
    }




    public void OnPointerEnter(PointerEventData eventData)
    {
        if (thisSlot.item != null)
        {
            if (!popupWindowObject.activeInHierarchy)
            {
                popupWindowObject.SetActive(true);
                UpdateInfoWindow();
                popupWindowTransform.position = thisSlotTransform.position + difference;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (popupWindowObject.activeInHierarchy)
        {
            popupWindowObject.SetActive(false);
        }
        
    }


    // Update is called once per frame
    void UpdateInfoWindow()
    {
        itemDamage = GameObject.Find("ItemDamage").GetComponent<Text>();
        itemArmor = GameObject.Find("ItemArmor").GetComponent<Text>();


        itemName = GameObject.Find("ItemName").GetComponent<Text>();
        itemName.text = thisSlot.item.name;

        itemValue = GameObject.Find("ItemValue").GetComponent<Text>();
        itemValue.text = "O Value: " + thisSlot.item.resourcesValue;

        if (thisSlot.item.damageModifier != 0)
        {
            itemDamage.text = "Damage: " + thisSlot.item.damageModifier;
            itemArmor.text = " "; //solution for now
        }
        else
        {
            itemDamage.text = " ";
        }

        if (thisSlot.item.armorModifier != 0)
        {
            itemArmor.text = "Armor: " + thisSlot.item.armorModifier;
            itemDamage.text = " ";
        }
        else
        {
            itemArmor.text = " ";
        }

        

    }
}
