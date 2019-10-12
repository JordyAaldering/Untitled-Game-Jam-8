#pragma warning disable CS0649
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
        private Animator anim;
        
        private static readonly int AnimHorizontal = Animator.StringToHash("horizontal");
        private static readonly int AnimVertical = Animator.StringToHash("vertical");

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponentInChildren<Animator>();

            speed += Random.Range(-0.25f, 0.25f);
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

            Vector2 vel = rb.velocity.With(x: facingRight ? speed : -speed);
            rb.velocity = vel;
            
            anim.SetFloat(AnimHorizontal, vel.x);
            anim.SetFloat(AnimVertical, vel.y);
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
