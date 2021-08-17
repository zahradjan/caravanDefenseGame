using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
  public void SetScene(int sceneNumber)
    {
        StartCoroutine(LoadScene(sceneNumber));
       
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
    IEnumerator LoadScene(int sceneNumber){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
         SceneManager.LoadScene(sceneNumber);
    }

}
