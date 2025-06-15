using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject restartButton;     
    public Score scoreManager;

    public void PlayerDied()
    {
        scoreManager.PlayerDied();
        restartButton.SetActive(true);   // activate button
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // scene reload
    }
}

