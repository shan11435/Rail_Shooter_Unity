using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        //will display the text start when you start the game
        scoreText.text = "Start";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score = score + amountToIncrease;
        //will display the score on screen
        scoreText.text = score.ToString();
    }
}
