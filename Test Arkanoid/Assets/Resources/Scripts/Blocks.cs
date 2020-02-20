using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField]
    private Block[] blockArray = new Block[18];

    [SerializeField]
    protected Color[] colorVariant = new Color[4];

    [SerializeField]
    protected Sprite[] typeVariant = new Sprite[2];

    public static int blockCount;
    private const int StartBlockCound = 18;

    void Start()
    {
        blockCount = StartBlockCound;
        UpdateBlocks();
    }

    // обновление блоков
    private void UpdateBlocks()
    {
        // перебор блоков
        foreach(Block b in blockArray)
        {
            b.UpdateColor();
            b.UpdateType();
        }
    }
}