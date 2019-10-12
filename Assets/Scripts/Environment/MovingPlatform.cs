using UnityEngine;

namespace Environment
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private bool horizontal = true;
        [SerializeField] private float distance = 2f;
        [SerializeField] private float speed = 1f;

        private float direction = 1f;
        private float origin = 0f;

        private void Awake()
        {
            Vector2 position = transform.position;
            origin = horizontal ? position.x : position.y;

            distance += Random.Range(-0.25f, 0.25f);
            speed += Random.Range(-0.25f, 0.25f);
        }

        private void Update()
        {
            Vector2 position = transform.position;
            float start = horizontal ? position.x : position.y;

            if (start > origin + distance)
            {
                direction = -1f;
            }
            else if (start < origin - distance)
            {
                direction = 1f;
            }

            Vector2 dir = horizontal ? Vector2.right : Vector2.up;
            transform.Translate(direction * speed * Time.deltaTime * dir);
        }
    }
}
