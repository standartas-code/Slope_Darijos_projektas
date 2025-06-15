using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip deathSound;

    void Awake()
    {
        // Singleton — чтобы был один на сцену
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // не уничтожать при перезапуске
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDeathSound()
    {
        if (deathSound != null)
        {
            sfxSource.PlayOneShot(deathSound);
        }
    }
}

