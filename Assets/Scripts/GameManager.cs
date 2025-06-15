using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject restartButton;     
    public Score scoreManager;

    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
    }
    public void PlayerDied()
    {
        scoreManager.PlayerDied();
        restartButton.SetActive(true);   // activate button

        MusicManager.Instance.PlayDeathSound();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // scene reload
    }
}

