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
    
    //EquipmentManager equipmentManager;
    public GameObject gameManager;
    public GameObject UiCanvas;
    public Character selectedCharacter;
    int currentCharacterChoice;
    int CharactersInt;
    // public Vector3 playerSpawnPosition = new Vector3(0, 1, -7);
    public Character[] characters;

     void Start()
    {
        currentCharacterChoice = 0;
        CharactersInt = characters.Length - 1;
        CharacterSelect(currentCharacterChoice);
    }

    public void CharacterSelect(int characterChoice) 
    {
        characterChoice = currentCharacterChoice;
        // GameObject spawnedPlayer = Instantiate(player, playerSpawnPosition, Quaternion.identity) as GameObject;
        EquipmentManager equipmentManager = gameManager.GetComponent<EquipmentManager>();
        EquipedUI equipedUI = UiCanvas.GetComponent<EquipedUI>();

        equipmentManager.RemoveOldMesh();
        equipedUI.RemoveOldIcons();
        selectedCharacter = characters[characterChoice]; //order of this is important
        equipmentManager.UpdateCurrentMesh(selectedCharacter);
        equipedUI.InvokeCurrentIcons();
        //Debug.Log(selectedCharacter.characterName + " selected!");

        //selectedCharacter.SetDefaultBaseStats(); //needed when adding new character
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


    public void NextCharacterButton()
    {
        Debug.Log("currentCharacterChoice = " + currentCharacterChoice);
        if (currentCharacterChoice >= CharactersInt)
        {
            currentCharacterChoice = 0;
            CharacterSelect(currentCharacterChoice);
        }
        else
        {
            currentCharacterChoice += 1;
            CharacterSelect(currentCharacterChoice);
        }
        
    }
    public void previousCharacterButton()
    {
        Debug.Log("currentCharacterChoice = " + currentCharacterChoice);
        if (currentCharacterChoice <= 0)
        {
            currentCharacterChoice = CharactersInt;
            CharacterSelect(currentCharacterChoice);
        }
        else
        {
            currentCharacterChoice -= 1;
            CharacterSelect(currentCharacterChoice);
        }
    }

}