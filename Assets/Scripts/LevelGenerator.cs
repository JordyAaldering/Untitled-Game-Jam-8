using Extensions;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int levelSize = 8;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < levelSize; i++)
        {
            Instantiate(
                PieceManager.instance.pieces.GetRandom(),
                new Vector3(i * 8f, 0f, 0f),
                Quaternion.identity
            );
        }
    }
}
