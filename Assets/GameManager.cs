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
        
       

        checkIfIsAlreadyPlaying();
        

    }
  

    private void FixedUpdate()
    {
        stopMusingIfGameSceneIsOn();
        Debug.Log(SceneManager.GetActiveScene().name);
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


}
