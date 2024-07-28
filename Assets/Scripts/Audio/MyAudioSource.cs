using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MyAudioSource : MonoBehaviour
{
    public static MyAudioSource Instance { get; private set; }
    AudioSource AS;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AS = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlaySoundEffect(AudioClip SFX)
    {
        AS.PlayOneShot(SFX);
    }

    public void PlayMusic(AudioClip clip, bool doLoop)
    {
        AS.clip = clip;
        AS.loop = doLoop;
        AS.Play();
    }

    public void StopMusic()
    {
        AS.Stop();
    }
}
