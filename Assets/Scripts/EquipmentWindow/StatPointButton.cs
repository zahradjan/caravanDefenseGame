using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatPointButton : MonoBehaviour
{
    CharacterStats characterStats;
    public GameObject selectedCharacter;
    public Button thisButton;
    public int StatRequirement;
    public StatType statType;

    // Start is called before the first frame update
    private void Start()
    {
        thisButton.interactable = false;    
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
            if (characterStats.strength.getValue() == StatRequirement)
            {
                thisButton.interactable = true;
                Debug.Log("STR button enabled.");
            }
        }
        if ((int)statType == 1)
        {
            if (characterStats.agility.getValue() == StatRequirement)
            {
                thisButton.interactable = true;
            }
        }
        if ((int)statType == 2)
        {
            if (characterStats.wisdom.getValue() == StatRequirement)
            {
                thisButton.interactable = true;
            }
        }
    }
}
public enum StatType { Strength, Agility, Wisdom }
