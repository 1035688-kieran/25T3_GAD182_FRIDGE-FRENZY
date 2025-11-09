using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// THIS SCRIPT is for when the player presses the continue button on the end panel, it takes them to the mainmenu
/// </summary>
public class LevelEndManager : MonoBehaviour
{
    public GameObject congratsPanel; // Assign your CongratsPanel here in the Inspector
    public Button nextLevelButton; // Assign your button here in the Inspector

    void Start()
    {
        // Ensure the panel is initially hidden
        congratsPanel.SetActive(false);

        // Add listener to the button
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        }
    }

    // Call this method when the level is completed
    public void ShowCongratsPanel()
    {
        congratsPanel.SetActive(true);
    }

    void OnNextLevelButtonClick()
    {
        // Example: Load the next level scene
        // Replace "NextLevelSceneName" with the actual name of your next level scene
        SceneManager.LoadScene("MainMenuScene");
        // Or load the main menu: SceneManager.LoadScene("MainMenuSceneName");
    }
}
