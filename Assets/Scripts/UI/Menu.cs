#pragma warning disable CS0649
using Environment;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI sizeText;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject gameWonPanel;

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
        }

        public void GameWon()
        {
            gameWonPanel.SetActive(true);
        }
        
        public void SetLevelSize(float size)
        {
            sizeText.text = $"Level Size: {(int) size}";
            LevelGenerator.LevelSize = (int) size;
        }

        public void LoadScene(int scene) => SceneManager.LoadScene(scene);

        public void Quit() => Application.Quit();
    }
}
