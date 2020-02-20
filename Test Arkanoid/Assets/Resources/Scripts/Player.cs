using UnityEngine;

public class Player : MonoBehaviour
{
    public static Transform tran;
    private float mouseX; // позиция мыши на оси X
    private const float maxDistance = 1.85f; // максимальное расстояние от центра

    void Start()
    {
        tran = transform;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

            if (Mathf.Abs(mouseX) < maxDistance)
            {
                tran.position = new Vector2(mouseX, tran.position.y);
            }
            else
            {
                tran.position = new Vector2(mouseX < maxDistance ? -maxDistance : maxDistance, tran.position.y);
            }
        }

        if (!Game.isMove & Input.GetMouseButtonUp(0))
        {
            if (Game.isWin)
            {
                Game.Replay();
            }
            else if (Game.isFall)
            {
                Score.RemoveScore();
                Level.RemoveLevel();
                Game.Replay();
            }
            else
            {
                Ball.StartMove();
            }
        }
    }
}