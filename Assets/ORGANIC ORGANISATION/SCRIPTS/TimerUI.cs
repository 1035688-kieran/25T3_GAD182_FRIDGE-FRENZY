using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameManager gameManager;
    public GameOverManager gameOverManager; 

    private bool gameOverTriggered = false; // PREVENT DOUBLE GAME OVER

    void Update()
    {
        float remaining = Mathf.Max(0, gameManager.gameDuration - gameManager.timer);
        timerText.text = remaining.ToString("F1") + "s";

        // GAME OVER TRIGGER (INTEGRATED)
        if (remaining <= 0f && !gameOverTriggered)
        {
            gameOverTriggered = true;
            gameOverManager.GameOver();
        }
    }
}
