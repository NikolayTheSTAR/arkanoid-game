using System;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : Score
{
    [SerializeField] private Text text_ms;

    private static int maxScore = 0;
    private static Text text_static_ms;

    void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            maxScore = PlayerPrefs.GetInt("MaxScore");
        }
        
        text_static_ms = text_ms;

        UpdateMaxScore();
        UpdateText();
    }

    // обновление максимального счёта
    private static void UpdateMaxScore()
    {
        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("MaxScore", maxScore);
        }
    }

    // обновление текста
    private static void UpdateText()
    {
        text_static_ms.text = "рекорд: " + Convert.ToString(maxScore);
    }
}