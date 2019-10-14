using System.Collections;
using Enemy;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private bool isDead = false;
        
        private void FixedUpdate()
        {
            if (!isDead && transform.position.y < -5f)
                StartCoroutine(Die());
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && other.gameObject.GetComponent<EnemyController>().CanAttack)
                StartCoroutine(Die());
        }

        private IEnumerator Die()
        {
            isDead = true;
            
            GetComponentInChildren<PlayerAnimatorController>().Die();
            GetComponent<PlayerInputController>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            yield return new WaitForSeconds(0.5f);

            FindObjectOfType<Menu>().GameOver();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("End"))
            {
                GetComponent<PlayerInputController>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                
                FindObjectOfType<Menu>().GameWon();
            }
        }
    }
}
