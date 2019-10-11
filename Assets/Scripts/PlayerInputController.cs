using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private CharacterController2D controller;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        bool crouch = Input.GetKeyDown(KeyCode.LeftControl);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        
        controller.Move(move, crouch, jump);
    }
}
