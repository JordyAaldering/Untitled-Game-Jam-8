using Environment;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        public void SetLevelSize(float size) => LevelGenerator.LevelSize = (int) size;

        public void LoadScene(int scene) => SceneManager.LoadScene(scene);

        public void Quit() => Application.Quit();
    }
}
