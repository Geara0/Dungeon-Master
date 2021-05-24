using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    public int score = 0;
    public int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    public void AddPoints(int amount)
    {
        score += amount;
        scoreText.text = score.ToString() + " POINTS";
        if(highScore < score)
            PlayerPrefs.SetInt("highScore", score);
    }
}
