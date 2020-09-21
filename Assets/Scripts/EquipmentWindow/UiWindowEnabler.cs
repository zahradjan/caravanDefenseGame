using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiWindowEnabler : MonoBehaviour
{
    private CharacterSkills characterSkills;
    CharacterSelector characterSelector;
    public GameObject skillsUI;
    public GameObject mapUI;
    public GameObject lootUI;
    public Canvas youSureCanvas;
    public ConfirmationDialog confirmationDialog;

    private void Start()
    {
        lootUI.SetActive(true);
    }

    public void Update()
    {
        //SetCharacterSkills(characterSelector.selectedCharacter.GetCharacterSkills()); // null reference error
    }


    public void EnableSkillsUI()
    {
        skillsUI.SetActive(true);
    }
    public void DisableSkillsUI()
    {
     skillsUI.SetActive(false);
    }

    public void EnableMapUI()
    {
        mapUI.SetActive(true);
    }
    public void DisableMapUI()
    {
        mapUI.SetActive(false);
    }

    public void EnableLootUI() //enable at the start
    {
        lootUI.SetActive(true);
    }
    public void DisableLootUI() //disable by button
    {
        lootUI.SetActive(false);
    }

 

    private void SetCharacterSkills(CharacterSkills characterSkills)
    {
        this.characterSkills = characterSkills;
    }

}
