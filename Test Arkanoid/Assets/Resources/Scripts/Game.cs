using UnityEngine.SceneManagement;

public static class Game
{
    public static bool isMove = false; // истинно во время движения
    public static bool isWin = false; // истинно во время победы
    public static bool isFall = false; // истинно во время поражения

    // перезапуск
    public static void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isMove = false;
        isWin = false;
        isFall = false;
    }
}