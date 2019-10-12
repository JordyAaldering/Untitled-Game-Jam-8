using Extensions;
using UnityEngine;

namespace Environment
{
    public class RandomBG : MonoBehaviour
    {
        [SerializeField] private Sprite[] bgs = new Sprite[0];

        private void Awake()
        {
            GetComponent<SpriteRenderer>().sprite = bgs.GetRandom();
        }
    }
}
