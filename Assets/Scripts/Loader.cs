﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Loader
{
    public enum Scene
    {
        GameScene,
    }

    public static void Load(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }
}