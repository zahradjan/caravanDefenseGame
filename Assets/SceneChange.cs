using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;
    public float delayTime = 3f;

    private void Start()
    {
        SetScene(1);

    }
    public void SetScene(int sceneNumber)
    {
        StartCoroutine(LoadScene(sceneNumber));

    }


    IEnumerator LoadScene(int sceneNumber)
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(delayTime);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneNumber);
    }
}
