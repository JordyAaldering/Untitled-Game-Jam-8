using Enemy;
using UnityEngine;

namespace Player
{
    public class Hurt : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
                StartCoroutine(other.GetComponent<EnemyController>().Hurt());
        }
    }
}
