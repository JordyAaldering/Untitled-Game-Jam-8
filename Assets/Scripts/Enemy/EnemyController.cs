using System.Collections;
using Extensions;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public bool CanAttack { get; private set; } = true;
        private bool isDead;
        
        private Animator anim;
        private EnemyMovement movement;
        
        private static readonly int AnimAttack = Animator.StringToHash("attack");
        private static readonly int AnimHurt = Animator.StringToHash("hurt");
        private static readonly int AnimDie = Animator.StringToHash("die");
        private static readonly int AnimIsDead = Animator.StringToHash("isDead");

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            movement = GetComponent<EnemyMovement>();
        }
        
        private void Attack()
        {
            anim.SetTrigger(AnimAttack);
        }

        public IEnumerator Hurt()
        {
            CanAttack = false;
            movement.enabled = false;
            anim.SetTrigger(AnimHurt);
            
            yield return new WaitForSeconds(1f);
            
            if (!isDead)
            {
                movement.enabled = true;
                CanAttack = !isDead;
            }
        }

        public void Die()
        {
            if (isDead)
                return;
            
            isDead = true;
            CanAttack = false;
            movement.enabled = false;

            CapsuleCollider2D col = GetComponent<CapsuleCollider2D>();
            col.offset = col.offset.With(y: -0.5f);
            
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            
            anim.SetBool(AnimIsDead, true);
            anim.SetTrigger(AnimDie);
            enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (CanAttack && other.gameObject.CompareTag("Player"))
            {
                Attack();
            }
        }
    }
}
