using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsUI : MonoBehaviour
{

    public GameObject skillsUI;

    public void EnableSkillsUI()
    {
        //skillsUI.SetActive(!skillsUI.activeSelf); //alternativní možnost
        skillsUI.SetActive(true);

    }

    public void DisableSkillsUI()
    {
     skillsUI.SetActive(false);

    }

}
