using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
   
    public static VideoController instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    //public void PlayVideo()//We don't need Play for your problem.
    //{
    //    //musicSource.clip = clip;
    //    videoSource.Play();
    //}

    //public void StopVideo()
    //{
    //    //musicSource.clip = clip;
    //    videoSource.Stop();
    //}

}

