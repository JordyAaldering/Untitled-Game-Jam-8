using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private void Update()
        {
            if (transform.position.y < -5f)
                SceneManager.LoadScene(0);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                GetComponentInChildren<PlayerAnimatorController>().Die();
                GetComponent<PlayerInputController>().enabled = false;
                GetComponent<CharacterController2D>().enabled = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("End"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
