using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;     // nuoroda i UI teksta
    public float pointsPerSecond = 1f;

    private float currentScore = 0f;
    private bool isAlive = true;

    //private float bestScore = 0f;
    //public TMP_Text bestScoreText;

    void Update()
    {
        if (!isAlive) return;
        if (!isAlive) return;

        currentScore += pointsPerSecond * Time.deltaTime/2;
        scoreText.text = Mathf.FloorToInt(currentScore).ToString();
        //bestScoreText.text = Mathf.FloorToInt(bestScore).ToString();
    }

    public void PlayerDied()
    {
        isAlive = false;

        /*
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            Debug.Log(Mathf.FloorToInt(bestScore));
        }*/
    }
}
