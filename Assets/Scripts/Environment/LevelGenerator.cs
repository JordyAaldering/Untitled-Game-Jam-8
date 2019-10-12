using Extensions;
using UnityEngine;

namespace Environment
{
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
            Instantiate(
                PieceManager.instance.pieceStart,
                Vector3.zero,
                Quaternion.identity
            ).transform.parent = transform;

            int xPos = 8;
            int yPos = yOffset.RandomBetween();
            for (int i = 0; i < levelSize - 2; i++)
            {
                Instantiate(
                    PieceManager.instance.pieces.GetRandom(),
                    new Vector3(xPos, yPos, 0f),
                    Quaternion.identity
                ).transform.parent = transform;

                xPos += 8 + xOffset.RandomBetween();
                yPos += yOffset.RandomBetween();
            }

            Instantiate(
                PieceManager.instance.pieceEnd,
                new Vector3(xPos, yPos, 0f),
                Quaternion.identity
            ).transform.parent = transform;
        }
    }
}
