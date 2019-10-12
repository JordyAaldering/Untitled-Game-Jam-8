using UnityEngine;

namespace Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private Animator anim;
        
        private static readonly int AnimHorizontal = Animator.StringToHash("horizontal");
        private static readonly int AnimVertical = Animator.StringToHash("vertical");
        private static readonly int AnimAttack = Animator.StringToHash("attack");
        private static readonly int AnimHurt = Animator.StringToHash("hurt");
        private static readonly int AnimDie = Animator.StringToHash("die");
        private static readonly int AnimRun = Animator.StringToHash("run");
        private static readonly int AnimJump = Animator.StringToHash("jump");
        private static readonly int AnimCrouch = Animator.StringToHash("crouch");
        private static readonly int AnimLand = Animator.StringToHash("land");

        private void Awake()
        {
            anim = GetComponent<Animator>();

            CharacterController2D controller = GetComponentInParent<CharacterController2D>();
            controller.OnCrouchEvent.AddListener(Crouch);
            controller.OnLandEvent.AddListener(Land);
        }

        public void Move(Vector2 velocity)
        {
            anim.SetFloat(AnimHorizontal, velocity.x);
            anim.SetFloat(AnimVertical, velocity.y);
        }

        public void Attack()
        {
            anim.SetTrigger(AnimAttack);
        }

        public void Hurt()
        {
            anim.SetTrigger(AnimHurt);
        }

        public void Die()
        {
            anim.SetTrigger(AnimDie);
        }

        public void Run(bool run)
        {
            anim.SetBool(AnimRun, run);
        }

        public void Jump()
        {
            anim.SetTrigger(AnimJump);
        }

        private void Crouch(bool crouch)
        {
            anim.SetBool(AnimCrouch, crouch);
        }

        private void Land()
        {
            Debug.Log("land");
            anim.SetTrigger(AnimLand);
        }
    }
}
