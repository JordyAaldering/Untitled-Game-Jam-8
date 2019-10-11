using Extensions;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int levelSize = 8;

    [SerializeField] private Vector2 xOffset = Vector2.zero;
    [SerializeField] private Vector2 yOffset = Vector2.zero;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        int xPos = 8;
        
        for (int i = 0; i < levelSize; i++)
        {
            Instantiate(
                PieceManager.instance.pieces.GetRandom(),
                new Vector3(xPos, yOffset.RandomBetween(), 0f),
                Quaternion.identity
            );

            xPos += 8 + xOffset.RandomBetween();
        }
    }
}
