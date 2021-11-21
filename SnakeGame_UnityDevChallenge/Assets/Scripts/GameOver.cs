using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameOver : MonoBehaviour
{
    public TMP_Text showScore;
    public TMP_Text score;

    void Start()
    {
        //Show the achived score
        showScore.text = score.text;

        //Check if the achived score was higher than the all time Top Score
        if(Int32.Parse(score.text)> PlayerPrefs.GetInt("TopScore"))
        {
            PlayerPrefs.SetInt("TopScore", Int32.Parse(score.text));
        }
    }

}
