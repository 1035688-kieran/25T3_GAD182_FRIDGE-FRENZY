using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonSequenceManager : MonoBehaviour
{
    public List<Button> correctSequenceButtons; // Assign in Inspector
    private List<Button> playerInputSequence;
    private int currentSequenceIndex;

    void Awake()
    {
        InitializeSequence();
    }

    void InitializeSequence()
    {
        playerInputSequence = new List<Button>();
        currentSequenceIndex = 0;
    }

    // Call this method from each button's OnClick event
    public void OnButtonPressed(Button pressedButton)
    {
        if (currentSequenceIndex < correctSequenceButtons.Count)
        {
            if (pressedButton == correctSequenceButtons[currentSequenceIndex])
            {
                playerInputSequence.Add(pressedButton);
                currentSequenceIndex++;

                if (currentSequenceIndex == correctSequenceButtons.Count)
                {
                    Debug.Log("Correct sequence completed!");
                    // Add code here for what happens when the sequence is correct
                    // For example, load next level, display success message, etc.
                }
            }
            else
            {
                Debug.Log("Incorrect button pressed! Resetting sequence.");
                RestartScene(); // Reset the sequence
            }
        }
        else
        {
            // This case should ideally not be reached if the sequence is completed
            // and you've handled the completion, but good for robustness.
            Debug.Log("Sequence already completed or unexpected state.");
            InitializeSequence();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
