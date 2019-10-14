using UnityEngine;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        private float move;
        private bool run, crouch, jump;

        private CharacterController2D cc;
        private PlayerAnimatorController anim;

        private void Awake()
        {
            cc = GetComponent<CharacterController2D>();
            anim = GetComponentInChildren<PlayerAnimatorController>();
        }

        private void Update()
        {
            move = Input.GetAxis("Horizontal");
            
            run = Input.GetButton("Sprint");
            anim.Run(run);

            crouch = Input.GetButton("Crouch");
            anim.Crouch(crouch);

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                anim.Jump();
            }

            if (Input.GetButtonDown("Fire"))
                anim.Attack();
        }

        private void FixedUpdate()
        {
            cc.Move(move, run, crouch, jump);
            jump = false;
        }
    }
}
