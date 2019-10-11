using UnityEngine;

namespace Extensions
{
    public static class Vector2Extensions
    {
        public static int RandomBetween(this Vector2 vector)
        {
            return Random.Range((int) vector.x, (int) vector.y);
        }
    }
}
