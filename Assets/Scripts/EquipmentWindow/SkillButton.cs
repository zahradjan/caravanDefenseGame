using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SkillButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject selectedCharacter;
    public Button thisButton;
    public Button buyButton;
    public GameObject popupWindowObject;
    Text skillName;
    Text skillDescription;
    Text skillRequirement;

    private void Start()
    {
        popupWindowObject.SetActive(false);

    }

    private void Update() //make it onItemChangedCallBack
    {
        UpdateInfoWindow();
    }

    void UpdateInfoWindow()
    {
        skillName = GameObject.Find("SkillName").GetComponent<Text>();
        skillName.text = "Heavy Attack";

        skillRequirement = GameObject.Find("SkillRequirement").GetComponent<Text>();
        skillRequirement.text = "Requires: " + thisButton.GetComponent<StatUnlockButton>().StatRequirement + " STR";



    }




    public void OnPointerEnter(PointerEventData eventData)
    {
       
            popupWindowObject.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        popupWindowObject.SetActive(false);
    }
}

