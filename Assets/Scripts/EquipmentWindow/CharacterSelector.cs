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

    //public GameObject characterSelectPanel;
   // public GameObject abilityPanel;


    public void CharacterSelect(int characterChoice)
    {
       // characterSelectPanel.SetActive(false);
        //abilityPanel.SetActive(true);
       // GameObject spawnedPlayer = Instantiate(player, playerSpawnPosition, Quaternion.identity) as GameObject;
       
        
        selectedCharacter = characters[characterChoice];
        Debug.Log(selectedCharacter.characterName + " selected!");
        
    
    }
}