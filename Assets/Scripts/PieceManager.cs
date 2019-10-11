using UnityEngine;

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
}
