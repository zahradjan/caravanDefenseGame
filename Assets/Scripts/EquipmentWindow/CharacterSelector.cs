using UnityEngine;
using System.Collections;

public class CharacterSelector : MonoBehaviour
{
    #region Singleton
    public static CharacterSelector instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    public Character selectedCharacter;

   // public Vector3 playerSpawnPosition = new Vector3(0, 1, -7);
    public Character[] characters;

   

    public void CharacterSelect(int characterChoice)
    {
       // GameObject spawnedPlayer = Instantiate(player, playerSpawnPosition, Quaternion.identity) as GameObject;
       
        
        selectedCharacter = characters[characterChoice];
        Debug.Log(selectedCharacter.characterName + " selected!");
        
    }


    public void LvlUpButton()
    {
        selectedCharacter.LevelUp();
    }
    public void StrengthUpButton()
    {
        selectedCharacter.IncreaseStrength();
    }
    public void AgilityUpButton()
    {
        selectedCharacter.IncreaseAgility();
    }
    public void WisdomUpButton()
    {
        selectedCharacter.IncreaseWisdom();
    }

}