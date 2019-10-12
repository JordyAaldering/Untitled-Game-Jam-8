using Extensions;
using UnityEngine;

namespace Environment
{
    public class RandomBG : MonoBehaviour
    {
        [SerializeField] private Sprite[] bgs = new Sprite[0];
        
        public static bool Randomize = true;
        private static Sprite last;

        private void Awake()
        {
            if (Randomize)
            {
                last = bgs.GetRandom();
            }
            
            GetComponent<SpriteRenderer>().sprite = last;
        }
    }
}
