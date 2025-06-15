using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip musicClip;

    void Start()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = musicClip;
        audio.loop = true;
        audio.playOnAwake = true;
        audio.Play();

        DontDestroyOnLoad(gameObject);
    }
}

