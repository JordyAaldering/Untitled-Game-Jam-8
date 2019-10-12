using UnityEngine;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        private float move;
        private bool run;
        private bool crouch;
        private bool jump;

        private CharacterController2D controller;

        private void Awake()
        {
            controller = GetComponent<CharacterController2D>();
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
        }

        private void FixedUpdate()
        {
            controller.Move(move, run, crouch, jump);

            crouch = false;
            jump = false;
        }
    }
}
