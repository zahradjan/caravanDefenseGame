using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class MusicController : MonoBehaviour
    {
        public AudioSource musicSource;
        public static MusicController instance = null;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void PlayMusic()//We don't need Play for your problem.
        {
            //musicSource.clip = clip;
            musicSource.Play();
        }

        public void StopMusic()
        {
            //musicSource.clip = clip;
            musicSource.Stop();
        }
    }

