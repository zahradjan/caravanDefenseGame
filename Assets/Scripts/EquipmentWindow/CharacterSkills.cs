using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSkills
{
    public enum Skill {
        HeavyAttack,
        SnipeShot,
        Heal,
         }

    private List<Skill> unlockedSkillsList;

    public CharacterSkills()
    {
        unlockedSkillsList = new List<Skill>();


    }

    public void UnlockSkill(Skill skill)
    {
        unlockedSkillsList.Add(skill);
    }

    public bool isSkillUnlocked(Skill skill)
    {
        return unlockedSkillsList.Contains(skill);
    }

}


