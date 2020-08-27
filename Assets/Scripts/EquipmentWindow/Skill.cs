using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    new public string name = "New Skill";
    public Sprite icon = null;

   

   
   public void AddSkill()
    {
        //add this skill
        Debug.Log("Skill Added!");

    }
}
