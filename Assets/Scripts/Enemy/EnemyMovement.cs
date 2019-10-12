using Extensions;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform wallCheck;

        private bool facingRight = true;
        private bool canFlip = false;
        
        private Rigidbody2D rb;

        private void Start ()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Collider2D[] cols = new Collider2D[1];
            int groundSize = Physics2D.OverlapCircleNonAlloc(groundCheck.position, 0.1f, cols, whatIsGround);
            if (canFlip && groundSize == 0)
            {
                canFlip = false;
                Flip();
            }
            else
            {
                int wallSize = Physics2D.OverlapCircleNonAlloc(wallCheck.position, 0.1f, cols, whatIsGround);
                if (canFlip && wallSize > 0)
                {
                    canFlip = false;
                    Flip();
                }
            }
            
            canFlip = groundSize > 0;

            Vector3 vel = rb.velocity;
            rb.velocity = vel.With(x: facingRight ? speed : -speed);
        }
        
        private void Flip()
        {
            facingRight = !facingRight;

            Transform t = transform;
            Vector3 scale = t.localScale;
            t.localScale = scale.With(x: -scale.x);
        }
    }
}
