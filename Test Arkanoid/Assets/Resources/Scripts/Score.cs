using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text text_s;

    public static int score = 0;
    private static Text text_static_s;

    void Start()
    {   
        text_static_s = text_s;
        UpdateText();
    }

    // пополнение счёта
    public static void AddScore()
    {
        score++;
        UpdateText();
    }

    // удаление счёта
    public static void RemoveScore()
    {
        score = 0;
        UpdateText();
    }

    // обновление текста
    private static void UpdateText()
    {
        text_static_s.text = "счёт: " + Convert.ToString(score);
    }
}