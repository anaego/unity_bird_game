using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    private void Awake()
    {
        Button play_button = transform.Find("PlayBtn").Find("Button").GetComponent<Button>();
        play_button.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        Button quit_button = transform.Find("QuitBtn").Find("Button").GetComponent<Button>();
        quit_button.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
