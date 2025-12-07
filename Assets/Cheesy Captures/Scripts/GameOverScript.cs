using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false); // Hide at start
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);  // Show on game over
        Time.timeScale = 0f;            // Optional: pause the game
    }
}
