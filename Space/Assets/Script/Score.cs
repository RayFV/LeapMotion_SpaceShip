using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text highScore;
    public TMP_Text score;

    // Use this for initialization
    void Start()
    {
        Data.Load();
        Data.score = 0;
        highScore.SetText("High Score:\n" + Data.highScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        score.SetText(Data.score.ToString());
    }
}
