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

        public void SetLevelSize(float amount)
        {
            int size = (int) amount;
            sizeText.text = $"Level Size: {size}";
            LevelGenerator.LevelSize = size;
        }

        public void LoadScene(int scene)
        {
            RandomBG.Randomize = SceneManager.GetActiveScene().buildIndex > 0;
            SceneManager.LoadScene(scene);
        }

        public void GameOver() => gameOverPanel.SetActive(true);

        public void GameWon() => gameWonPanel.SetActive(true);

        public void Quit() => Application.Quit();
    }
}
