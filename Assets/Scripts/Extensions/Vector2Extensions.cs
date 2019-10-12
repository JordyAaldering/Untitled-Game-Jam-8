using UnityEngine;

namespace Extensions
{
    public static class Vector2Extensions
    {
        public static int RandomBetween(this Vector2 vector)
        {
            return Random.Range((int) vector.x, (int) vector.y);
        }
        
        public static Vector2 With(this Vector2 original, float? x = null, float? y = null)
        {
            return new Vector2(x ?? original.x, y ?? original.y);
        }
    }
}
