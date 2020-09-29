using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour
{
    [HideInInspector]
    public int inventorySlotIndex = 0, equipedSlotIndex = 1, lootSlotIndex = 2;
    [HideInInspector]
    public int slotType;
    public GameObject canvas;
    public Image icon;
    public Item item;
    public Button removeButton;
    UiWindowEnabler skillsNLootUiEnable;
    private Coroutine coroutine;
    Text question;

    public virtual void Start()
    {
        slotType = inventorySlotIndex;
        skillsNLootUiEnable = canvas.GetComponent<UiWindowEnabler>();
        //popupWindowObject.SetActive(false);
    }


    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        
    }

    public virtual void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

        ItemInfoUI itemInfoUI = gameObject.GetComponent<ItemInfoUI>();
        GameObject popUpWindow = itemInfoUI.popupWindowObject;
        itemInfoUI.popupWindowObject.SetActive(false);
    }

    public virtual void OnRemoveButton()
    {
        StartCoroutine(ShowConfirmationDialog());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (coroutine == null)
            {
                coroutine = StartCoroutine(ShowConfirmationDialog());
            }
        }
    }

    IEnumerator ShowConfirmationDialog()
    {
        ConfirmationDialog confirmationDialog = canvas.GetComponent<UiWindowEnabler>().confirmationDialog;
        Canvas youSureCanvas = canvas.GetComponent<UiWindowEnabler>().youSureCanvas;
        ConfirmationDialog dialog = Instantiate(confirmationDialog, youSureCanvas.transform); // instantiate the UI dialog box
        ConfirmationUI();
        while (dialog.result == dialog.NONE)
        {
            //Debug.Log(" Yielding");

            yield return null; // wait
        }

        if (dialog.result == dialog.YES)
        {
            if (slotType == inventorySlotIndex)
            {
                Resources.instance.AddResources(item.resourcesValue);
                Inventory.instance.Remove(item);
            }
            if (slotType == lootSlotIndex)
            {
                Resources.instance.AddResources(item.resourcesValue);
                Destroy(gameObject);  
            }

            //ADD ITEM VALUE TO RESOURCES

        }
        else if (dialog.result == dialog.CANCEL)
        {
            Debug.Log(" confirm Cancel");
        }

        Destroy(dialog.gameObject);

        coroutine = null;
    }

    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
        }
    }

   

    private void ConfirmationUI()
    {
        question = GameObject.Find("questionText").GetComponent<Text>();
        question.text = "Do you realy want to dismantle " + item.name + " for " +  item.resourcesValue + " resources?";
    }


}
