using UnityEngine;
using UnityEngine.UI;

public class StatUnlockButton : MonoBehaviour
{
    public GameObject selectedCharacter;
    public Button thisButton;
    public int StatRequirement;
    public StatType statType;

    // Start is called before the first frame update
    private void Start()
    {
       
    
    }

    // Update is called once per frame
    void Update()
    {
        EnableButton();
    }

    public void EnableButton()
    {
        if ((int)statType == 0)
        {
            int charactersStrength = selectedCharacter.GetComponent<CharacterStats>().strength.getValue();

            if (charactersStrength >= StatRequirement)
            {
                thisButton.interactable = true;
            }
        }
        if ((int)statType == 1)
        {
            int charactersAgility = selectedCharacter.GetComponent<CharacterStats>().agility.getValue();

            if (charactersAgility >= StatRequirement)
            {
                thisButton.interactable = true;
            }
        }
        if ((int)statType == 2)
        {
            int charactersWisdom = selectedCharacter.GetComponent<CharacterStats>().wisdom.getValue();

            if (charactersWisdom >= StatRequirement)
            {
                thisButton.interactable = true;
            }
        }
    } 
}
public enum StatType { Strength, Agility, Wisdom }
