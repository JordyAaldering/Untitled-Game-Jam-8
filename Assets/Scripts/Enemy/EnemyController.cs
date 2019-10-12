using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private Animator anim;
        
        private static readonly int AnimAttack = Animator.StringToHash("attack");
        private static readonly int AnimHurt = Animator.StringToHash("hurt");
        private static readonly int AnimDie = Animator.StringToHash("die");

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
        }
        
        private void Attack()
        {
            anim.SetTrigger(AnimAttack);
        }

        private void Hurt()
        {
            anim.SetTrigger(AnimHurt);
        }

        private void Die()
        {
            GetComponent<EnemyMovement>().enabled = false;
            anim.SetTrigger(AnimDie);
        }
    }
}
