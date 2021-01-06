using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private SceneManager sceneManager;
    private void Awake()
    {

        placementMode();

        //checkIfIsAlreadyPlaying();
        

    }
  

    private void FixedUpdate()
    {
        //stopMusingIfGameSceneIsOn();
        //Debug.Log(SceneManager.GetActiveScene().name);
    }

    private static void stopMusingIfGameSceneIsOn()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            MusicController.instance.StopMusic();
           
        }
    }

    private void checkIfIsAlreadyPlaying()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void playMode()
    {
        GameObject.Find("Placement").SetActive(false);
        GameObject[] team1 = GameObject.FindGameObjectsWithTag("Team1");
        GameObject[] team2 = GameObject.FindGameObjectsWithTag("Team2");
        enableWCInTeam(team1);
        enableWCInTeam(team2);



    }
    public void placementMode()
    {
        GameObject[] team1 = GameObject.FindGameObjectsWithTag("Team1");
        GameObject[] team2 = GameObject.FindGameObjectsWithTag("Team2");
        disableWCInTeam(team1);
        disableWCInTeam(team2);
    }

    void disableWCInTeam(GameObject[] team)
    {
        foreach (GameObject gameObject in team)
        {
            if (gameObject.name != "Collider")
            {
                gameObject.GetComponent<WarriorControl>().enabled = false;
                gameObject.GetComponent<detectHit>().enabled = false;
            }
        }
    }

    void enableWCInTeam(GameObject[] team)
    {
        foreach (GameObject gameObject in team)
        {
            if (gameObject.name != "Collider")
            {
                gameObject.GetComponent<WarriorControl>().enabled = true;
                gameObject.GetComponent<detectHit>().enabled = true;
            }
        }
    }

}
