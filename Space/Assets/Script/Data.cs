using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Data
{
    public static int highScore;
    public static int score;

    public static void Load()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    public static void Save()
    {
        if (score > highScore)
            highScore = score;

        PlayerPrefs.SetInt("highScore", highScore);
    }
}
