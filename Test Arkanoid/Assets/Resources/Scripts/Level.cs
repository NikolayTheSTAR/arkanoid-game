using System;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Text text;

    private static int level = 1;
    private static Text text_static;

    void Start()
    {
        text_static = text;
        UpdateText();
    }

    // повышение уровня
    public static void AddLevel()
    {
        level++;
        UpdateText();
    }

    // удаление уровня
    public static void RemoveLevel()
    {
        level = 1;
        UpdateText();
    }

    // обновление текста
    private static void UpdateText()
    {
        text_static.text = "уровень: " + Convert.ToString(level);
    }
}