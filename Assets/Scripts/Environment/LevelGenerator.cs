using System;
using Extensions;
using UnityEngine;
using Utilities;

namespace Environment
{
    public class LevelGenerator : MonoBehaviour
    {
        public static int LevelSize = 8;

        [SerializeField] private Vector2 xOffset = Vector2.zero;
        [SerializeField] private Vector2 yOffset = Vector2.zero;

        private int XOffset => xOffset.RandomBetween();
        private int YOffset => yOffset.RandomBetween();

        private void Awake() => Generate();

        private void Generate()
        {
            CreatePiece(PieceManager.instance.Piece, -8 - XOffset, -YOffset);
            CreatePiece(PieceManager.instance.pieceStart, 0, 0);

            int xPos = 8;
            int yPos = yOffset.RandomBetween();
            
            for (int i = 1; i < LevelSize; i++)
            {
                CreatePiece(PieceManager.instance.Piece, xPos, yPos);
                
                xPos += 8 + XOffset;
                yPos += YOffset;
            }

            CreatePiece(PieceManager.instance.pieceEnd, xPos, yPos + 1);
        }

        private void CreatePiece(GameObject piece, int xPos, int yPos)
        {
            Instantiate(
                piece,
                new Vector3(xPos, yPos, 0f),
                Quaternion.identity
            ).transform.parent = transform;
        }
    }
}
