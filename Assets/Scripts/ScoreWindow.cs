using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text scoreText;
    private Text highScoreText;

    void Awake()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        highScoreText = transform.Find("HighScoreText").GetComponent<Text>();
    }

    private void Start()
    {
        highScoreText.text = "Highscore: " + Score.GetHighScore().ToString();
    }

    private void Update()
    {
        scoreText.text = (Level.GetInstance().GetPipesPassedCount() / 2).ToString();
    }

}
