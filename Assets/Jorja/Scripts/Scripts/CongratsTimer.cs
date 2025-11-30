using System.Collections;
using UnityEngine;

public class CongratsTimer : MonoBehaviour
{
    public GameObject targetPanel;   // Assign your UI Panel here
    public float delay = 2f;         // Time to wait before showing

    public void TogglePanel()
    {
        StartCoroutine(TogglePanelDelayed());
    }

    private System.Collections.IEnumerator TogglePanelDelayed()
    {
        // Wait even if the game is paused
        yield return new WaitForSecondsRealtime(delay);

        if (targetPanel != null)
        {
            // Toggle the panel on/off
            targetPanel.SetActive(!targetPanel.activeSelf);
        }
    }
} // DONT USE
