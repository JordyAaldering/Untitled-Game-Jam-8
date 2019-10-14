using System.Linq;
using UnityEngine;

namespace Utilities
{
    public class UniqueRandom
    {
        private readonly int[] last;

        public UniqueRandom(int size) => last = new int[size];

        public int Range(int from, int to)
        {
            int val;

            do val = Random.Range(from, to);
            while (last.Contains(val));

            return val;
        }
    }
}
