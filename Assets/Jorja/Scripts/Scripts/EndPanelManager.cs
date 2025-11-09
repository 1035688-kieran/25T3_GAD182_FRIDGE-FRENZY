using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// THIS SCRIPT is for when the player finishs the game/presses the last button, the end panel shows
/// </summary>
public class EndPanelManager : MonoBehaviour
{
    public GameObject targetPanel; // Assign your UI Panel here in the Inspector

    public void TogglePanel()
    {
        if (targetPanel != null)
        {
            // Toggles the active state of the panel
            targetPanel.SetActive(!targetPanel.activeSelf);
        }
    }
}
