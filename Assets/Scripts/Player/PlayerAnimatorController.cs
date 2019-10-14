using UnityEngine;

namespace Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private Animator anim;
        
        private static readonly int AnimHorizontal = Animator.StringToHash("horizontal");
        private static readonly int AnimVertical = Animator.StringToHash("vertical");
        private static readonly int AnimAttack = Animator.StringToHash("attack");
        private static readonly int AnimDie = Animator.StringToHash("die");
        private static readonly int AnimRun = Animator.StringToHash("run");
        private static readonly int AnimJump = Animator.StringToHash("jump");
        private static readonly int AnimCrouch = Animator.StringToHash("crouch");
        private static readonly int AnimLand = Animator.StringToHash("land");

        private void Awake()
        {
            anim = GetComponent<Animator>();
            GetComponentInParent<CharacterController2D>().OnLandEvent.AddListener(Land);
        }

        public void Move(Vector2 velocity)
        {
            anim.SetFloat(AnimHorizontal, Mathf.Abs(velocity.x));
            anim.SetFloat(AnimVertical, velocity.y);
        }

        public void Attack() => anim.SetTrigger(AnimAttack);

        public void Die() => anim.SetTrigger(AnimDie);

        public void Run(bool run) => anim.SetBool(AnimRun, run);

        public void Jump() => anim.SetTrigger(AnimJump);

        public void Crouch(bool crouch) => anim.SetBool(AnimCrouch, crouch);

        private void Land() => anim.SetTrigger(AnimLand);
    }
}
