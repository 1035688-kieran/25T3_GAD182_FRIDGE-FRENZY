using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameManager gameManager;

    void Update()
    {
        float remaining = Mathf.Max(0, gameManager.gameDuration - gameManager.timer);
        timerText.text = remaining.ToString("F1") + "s";
    }
}