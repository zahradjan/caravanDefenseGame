using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsUI : MonoBehaviour
{
    private CharacterSkills characterSkills;
    CharacterSelector characterSelector;
    public GameObject skillsUI;


    public void Update()
    {
        SetCharacterSkills(characterSelector.selectedCharacter.GetCharacterSkills());
    }


    public void EnableSkillsUI()
    {
        skillsUI.SetActive(true);
    }
    public void DisableSkillsUI()
    {
     skillsUI.SetActive(false);
    }


    private void SetCharacterSkills(CharacterSkills characterSkills)
    {
        this.characterSkills = characterSkills;
    }

}
