using UnityEngine;
using UnityEngine.SceneManagement; // So I can reload scene or switch scenes

public class GameManager : MonoBehaviour
{
    public float gameDuration = 60f; // 60 seconds
    public float timer = 0f;
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        timer += Time.deltaTime;

        if (timer >= gameDuration)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");

        // Option 1: Stop time
        Time.timeScale = 0f;

    }
}
