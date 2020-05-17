using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Loader
{
    public enum Scene
    {
        GameScene,
        Loading,
    }

    private static Scene targetScene;

    public static void Load(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.Loading.ToString());
        targetScene = scene;
    }

    public static void LoadTargetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene.ToString());
    }
}