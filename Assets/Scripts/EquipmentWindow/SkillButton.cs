using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SkillButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject gameManager;
    Character selectedCharacter;
    public Button thisButton;
    public Button buyButton;
    public GameObject popupWindowObject;
    Text skillName;
    Text skillDescription;
    Text skillRequirement;

    private void Start()
    {
        selectedCharacter = gameManager.GetComponent<CharacterSelector>().selectedCharacter;
        popupWindowObject.SetActive(false);

        Button btn = buyButton.GetComponent<Button>();
        btn.onClick.AddListener(BuyOnClick);

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
        skillRequirement.text = "Requires: " + thisButton.GetComponent<StatRequirementButton>().StatRequirement + " STR";



    }




    public void OnPointerEnter(PointerEventData eventData)
    {
            popupWindowObject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        popupWindowObject.SetActive(false);
    }


  

   public void BuyOnClick()
    {
        
        //UnlockSkill();
        Debug.Log("You unlocked " + "new skill");
    }
}

