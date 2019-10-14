using UnityEngine;
using Utilities;

namespace Environment
{
    public class PieceManager : MonoBehaviour
    {
        public static PieceManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.LogError("Instance already exists.");
                Destroy(gameObject);
            }
        }

        public GameObject pieceStart;
        public GameObject pieceEnd;

        public GameObject[] pieces;
        
        private readonly UniqueRandom Random = new UniqueRandom(3);
        public GameObject Piece => pieces[Random.Range(0, pieces.Length)];
    }
}
