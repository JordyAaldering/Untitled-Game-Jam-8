using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private void Update()
        {
            if (transform.position.y < -10f)
                SceneManager.LoadScene(0);
        }
    }
}
