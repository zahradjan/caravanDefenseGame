using UnityEngine;
using UnityEngine.UI;

public class StatRequirementButton : MonoBehaviour
{
    public GameObject gameManager;
    Character selectedCharacter;
    public Button thisButton;
    public int StatRequirement;
    public StatType statType;

    // Start is called before the first frame update
    private void Start()
    {
        CharacterSelector characterSelector  = gameManager.GetComponent<CharacterSelector>();
        selectedCharacter = characterSelector.selectedCharacter;

    }

    // Update is called once per frame
    void Update()
    {
        EnableButton();
    }

    public void EnableButton()
    {
        CharacterSelector characterSelector = gameManager.GetComponent<CharacterSelector>();
        selectedCharacter = characterSelector.selectedCharacter;
        if ((int)statType == 0)
        {
            int charactersStrength = selectedCharacter.strength.getValue();

            if (charactersStrength >= StatRequirement)
            {
                thisButton.interactable = true;
            }
            else
            {
                thisButton.interactable = false;
            }
        }
        

        if ((int)statType == 1)
        {
            int charactersAgility = selectedCharacter.agility.getValue();

            if (charactersAgility >= StatRequirement)
            {
                thisButton.interactable = true;
            }
            else
            {
                thisButton.interactable = false;
            }
        }
       

        if ((int)statType == 2)
        {
            int charactersWisdom = selectedCharacter.wisdom.getValue();

            if (charactersWisdom >= StatRequirement)
            {
                thisButton.interactable = true;
            }
            else
            {
                thisButton.interactable = false;
            }
        }  

    }
}
public enum StatType { Strength, Agility, Wisdom }
