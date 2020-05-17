using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private Text scoreText;

    private void Awake()
    {
        Debug.Log("IN GAMEOVER AWAKE");
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        Button button = transform.Find("RetryBtn").Find("Button").GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        Debug.Log("IN GAMEOVER AWAKE - AFTER ADDING EVENT");
    }

    private void Start()
    {
        Debug.Log("IN GAMEOVER START");
        Character.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Bird_OnDied(object sender, System.EventArgs e)
    {
        Debug.Log("IN GAMEOVER BIRD ONDIED");
        Show();
        scoreText.text = (Level.GetInstance().GetPipesPassedCount() / 2).ToString();
    }

    private void Hide()
    {
        Debug.Log("IN HIDE");
        gameObject.SetActive(false);
    }

    private void Show()
    {
        Debug.Log("IN SHOW");
        gameObject.SetActive(true);
    }
}
