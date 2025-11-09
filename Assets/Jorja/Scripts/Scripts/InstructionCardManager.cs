using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionCardManager : MonoBehaviour
{
    public GameObject instructionCardPanel; // Reference to your Panel or the parent of your instruction UI
    public Button closeButton; // Reference to your close button (if used)

    void Start()
    {
        // Show the instruction card at the start
        ShowInstructions();

        // If using a close button, add a listener
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(HideInstructions);
        }
    }

    public void ShowInstructions()
    {
        if (instructionCardPanel != null)
        {
            instructionCardPanel.SetActive(true);
        }
    }

    public void HideInstructions()
    {
        if (instructionCardPanel != null)
        {
            instructionCardPanel.SetActive(false);
        }
    }
}
