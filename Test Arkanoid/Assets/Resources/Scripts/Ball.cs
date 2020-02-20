using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Animator cameraAnim;

    private static Animator cameraAnim_static;
    private static float speed = 3;
    private static Transform tran;

    private const float standartSpeed = 3; // скорость по умолчанию
    private const float maxPosX = 2.56f; // максимальная позиция по X
    private const float maxPosY = 4.75f; // максимальное позиция по Y
    private const float upIndent = 0.55f; // отступ сверху
    private const float diaBall = 0.5f; // диаметр шарика

    private bool up = true; // движение вверх
    private bool right = true; // движение вправо

    void Start()
    {
        tran = transform;
        cameraAnim_static = cameraAnim;
    }

    // начало движения
    public static void StartMove()
    {
        Game.isMove = true;
        Game.isWin = false;
        Game.isFall = false;
        tran.parent = null;
    }

    void Update()
    {
        if (Game.isMove)
        {
            tran.Translate(new Vector2((right ? speed : -speed) * Time.deltaTime, (up ? speed : -speed) * Time.deltaTime));

            // проверка на выход за границы

            // по оси X

            if (right)
            {
                if (tran.position.x > maxPosX)
                {
                    right = false;
                }
            }
            else
            {
                if (tran.position.x < -maxPosX)
                {
                    right = true;
                }
            }

            // по оси Y

            if (up)
            {
                if (tran.position.y > maxPosY - upIndent)
                {
                    up = false;
                }
            }
            else
            {
                if (tran.position.y < -(maxPosY + diaBall))
                {
                    Fall();
                }
            }
        }
    }

    // падение
    private static void Fall()
    {
        Game.isMove = false;
        Game.isFall = true;
        cameraAnim_static.SetBool("Fall", true);
        speed = standartSpeed;
    }

    // победа
    public static void Win()
    {
        Game.isMove = false;
        Game.isWin = true;
        cameraAnim_static.SetBool("Win", true);
        Level.AddLevel();
        speed++;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (tran.position.y > Player.tran.position.y)
            {
                up = true;
            }
        }

        if (col.tag == "Block")
        {
            if (col.GetComponent<Block>().type == 'N')
            {
                // отражение

                float deltaX = col.transform.position.x - tran.position.x;
                float deltaY = col.transform.position.y - tran.position.y;

                // вертикальное
                if (Mathf.Abs(deltaY) >= Mathf.Abs(deltaX))
                {
                    up = !(deltaY > 0);
                }
                // горизонтальное
                else
                {
                    right = !(deltaX > 0);
                }
            }

            col.GetComponent<Block>().RemoveBlock();
        }
    }
}