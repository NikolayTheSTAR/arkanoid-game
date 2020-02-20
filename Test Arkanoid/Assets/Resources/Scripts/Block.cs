using UnityEngine;

public class Block : Blocks
{
    [SerializeField]
    private SpriteRenderer rend;

    [SerializeField]
    private Animator anim;

    public char type; // N - Normal, E - Empty

    // обновление цвета
    public void UpdateColor()
    {
        float r = Random.Range(0f, 1f);

        // занесение рандомного цвета
        if (r <= 0.25f)
        {
            rend.color = colorVariant[0];
        }
        else if (r <= 0.5f)
        {
            rend.color = colorVariant[1];
        }
        else if (r <= 0.75f)
        {
            rend.color = colorVariant[2];
        }
        else
        {
            rend.color = colorVariant[3];
        }
    }

    // обновление формы
    public void UpdateType()
    {
        float r = Random.Range(0f, 1f);

        // занесение рандомного спрайта
        if (r <= 0.66f)
        {
            rend.sprite = typeVariant[0];
            type = 'N';
        }
        else
        {
            rend.sprite = typeVariant[1];
            type = 'E';
        }
    }

    // уничтожение блока
    public void RemoveBlock()
    {
        anim.SetTrigger("Destroy");
        Blocks.blockCount--;
        Score.AddScore();

        if (Blocks.blockCount == 0)
        {
            Ball.Win();
        }
    }

    // удаление объекта
    void Destroy()
    {
        Destroy(gameObject);
    }
}