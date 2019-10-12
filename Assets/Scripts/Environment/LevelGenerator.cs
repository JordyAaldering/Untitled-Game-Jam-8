using System;
using Extensions;
using UnityEngine;

namespace Environment
{
    public class LevelGenerator : MonoBehaviour
    {
        public static int LevelSize = 8;

        [SerializeField] private Vector2 xOffset = Vector2.zero;
        [SerializeField] private Vector2 yOffset = Vector2.zero;

        private void Awake() => Generate();

        private void Generate()
        {
            Instantiate(
                PieceManager.instance.pieceStart,
                Vector3.zero,
                Quaternion.identity
            ).transform.parent = transform;

            int xPos = 8;
            int yPos = yOffset.RandomBetween();
            for (int i = 1; i < LevelSize; i++)
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
                new Vector3(xPos, yPos + 1f, 0f),
                Quaternion.identity
            ).transform.parent = transform;
        }
    }
}
