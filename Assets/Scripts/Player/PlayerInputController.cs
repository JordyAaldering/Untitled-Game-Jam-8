using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        private float move;
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
            crouch = Input.GetKey(KeyCode.LeftControl);
            jump = Input.GetKeyDown(KeyCode.Space);
        }

        private void FixedUpdate()
        {
            controller.Move(move, crouch, jump);
        }
    }
}
