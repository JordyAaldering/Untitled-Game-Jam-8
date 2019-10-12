using UnityEngine;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        private float move;
        private bool run, crouch, jump;
        private bool attack;

        private CharacterController2D controller;
        private PlayerAnimatorController anim;

        private void Awake()
        {
            controller = GetComponent<CharacterController2D>();
            anim = GetComponentInChildren<PlayerAnimatorController>();
        }

        private void Update()
        {
            move = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.LeftShift))
                run = true;
            else if (Input.GetKeyUp(KeyCode.LeftShift))
                run = false;

            if (Input.GetKey(KeyCode.LeftControl))
                crouch = true;

            if (Input.GetKeyDown(KeyCode.Space))
                jump = true;

            if (Input.GetKeyDown(KeyCode.Q))
                attack = true;
            
            anim.Run(run);
            if (jump) anim.Jump();
            if (attack) anim.Attack();
        }

        private void FixedUpdate()
        {
            controller.Move(move, run, crouch, jump);

            crouch = false;
            jump = false;
            attack = false;
        }
    }
}
