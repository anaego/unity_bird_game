using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private Text scoreText;

    private void Awake()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        Button button = transform.Find("RetryBtn").Find("Button").GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        Button menu_button = transform.Find("MainMenuBtn").Find("Button").GetComponent<Button>();
        menu_button.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);
        });
    }

    private void Start()
    {
        Character.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Bird_OnDied(object sender, System.EventArgs e)
    {
        Show();
        scoreText.text = (Level.GetInstance().GetPipesPassedCount() / 2).ToString();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
